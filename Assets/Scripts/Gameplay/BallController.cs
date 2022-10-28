using Managers;
using UnityEngine;

namespace Gameplay
{
    public class BallController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float totalBallPushPower = 10f;
        [SerializeField] private float maxPullToPushBall = 1f;
        [SerializeField] private new Camera camera;
        [SerializeField] private GameManager gameManager;
        
        
        public Vector3 Position => _rigidbody.position;
        public bool IsMoving => _rigidbody.velocity.magnitude > 0.1f;
        public bool IsAiming => _isAiming;
        public Vector3 AimDirection => _aimDirection;
        public float PushPower => _pushPower;
        
        private bool _isAiming;
        

        private Transform _transform;
        private Vector3 _aimDirection;
        private float _pushPower;
        private bool _isBallClicked;

        private Vector3 _ballPosition;
        
        void Awake()
        {
            _isAiming = false;
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            _isBallClicked = false;
            _ballPosition = _transform.position;
        }
        
        void Update()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            ClickBall(ray);

            if (_isBallClicked)
            {
                DragMouseForBallMovement(ray);
            }
            ReleaseClickBall();
            StopBallWhenVelocityIsVerySmall();
        }

        private void StopBallWhenVelocityIsVerySmall()
        {
            if (_rigidbody.velocity.magnitude < 0.01f)
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }

        private void DragMouseForBallMovement(Ray ray)
        {
            if (!Physics.Raycast(ray, out var mouseHit, 1000))
            {
                _isBallClicked = false;
                _isAiming = false;

            }
            else
            {
                _isAiming = true;
               
                //Draw ray for debug
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                
                print(mouseHit.collider.name);
                _ballPosition = _transform.position;
                _aimDirection = GetAimDirection(mouseHit);
                _pushPower = GetPushPower(mouseHit);
            }
        }

        private float GetPushPower(RaycastHit mouseHit)
        {
            var ballToMouseDistance = _ballPosition - mouseHit.point;
            var pushPowerFactor = ballToMouseDistance.magnitude / maxPullToPushBall;
            var pushPower = pushPowerFactor * totalBallPushPower;

            if (pushPower > totalBallPushPower)
                pushPower = totalBallPushPower;

            print(pushPower);
            return pushPower;
        }

        private void ReleaseClickBall()
        {
            if (!Input.GetMouseButtonUp(1)) return;
            
            if (_isBallClicked)
            {
                _isBallClicked = false;
                _rigidbody.AddForce(_aimDirection * _pushPower, ForceMode.Impulse);
                gameManager.IncrementShotAttempts();
                _isAiming = false;

            }
        }

        private void ClickBall(Ray ray)
        {
            if (!Input.GetMouseButton(1)) return;
            if (!Physics.Raycast( ray, out var hit)) return;
            if (!hit.collider.gameObject.CompareTag("Ball")) return;
            _isBallClicked = true;
        }

        private Vector3 GetAimDirection(RaycastHit mouseHit)
        {
            var direction = _ballPosition - mouseHit.point;
            direction = Vector3.Normalize(direction);

            // horizontal direction
            var horizontalDirection = new Vector3(direction.x, 0, direction.z);
            return horizontalDirection;
        }
    }
}