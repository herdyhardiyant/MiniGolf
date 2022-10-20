using UnityEngine;

namespace Scenes.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float forcePower = 100f;
        [SerializeField] private float maxPullToPushBall = 2f;
        [SerializeField] private new Camera camera;

        public Vector3 Position => _rigidbody.position;

        private Transform _transform;
        private Vector3 _aimDirection;
        private float _pushPower;
        private bool _isBallClicked;

        // Start is called before the first frame update
        void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            _isBallClicked = false;
            
        }

        // Update is called once per frame
        void Update()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            
            RightClickBall(ray);

            if (_isBallClicked)
            {
                if (!Physics.Raycast(ray, out var mouseHit))
                {
                    _isBallClicked = false;
                }

                var ballPosition = _transform.position;
                
                _aimDirection = GetAimDirection(ballPosition, mouseHit);
                
                //TODO Click on ball and drag it to move it
                // Get the distance from the ball to the mouse position
                var ballToMouseDistance = ballPosition - mouseHit.point;
                _pushPower = (ballToMouseDistance / maxPullToPushBall).magnitude * forcePower;
            }

            ReleaseClickBall();

        }

        private void ReleaseClickBall()
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (_isBallClicked)
                {
                    _isBallClicked = false;
                    _rigidbody.AddForce(_aimDirection * _pushPower, ForceMode.Impulse);
                }
            }
        }

        private void RightClickBall(Ray ray)
        {
            if (Input.GetMouseButton(1))
            {
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.gameObject.CompareTag("Ball"))
                    {
                        _isBallClicked = true;
                    }
                }
            }
        }

        private static Vector3 GetAimDirection(Vector3 ballPosition, RaycastHit mouseHit)
        {
            // Direction from ball to hit point
            var direction = ballPosition - mouseHit.point;
            direction = Vector3.Normalize(direction);

            // horizontal direction
            var horizontalDirection = new Vector3(direction.x, 0, direction.z);
            return horizontalDirection;
        }
    }
}