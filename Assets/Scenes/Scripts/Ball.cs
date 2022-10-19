using UnityEngine;

namespace Scenes.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float forcePower = 100f;
        [SerializeField] private float maxPullToPowerBallMovement = 5f;
        [SerializeField] private new Camera camera;

        public Vector3 Position => _rigidbody.position;

        private Transform _transform;
        private Vector3 _aimDirection;

        private float _pushPower;

        // Start is called before the first frame update
        void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            // Click on ball
            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (!hit.collider.gameObject.CompareTag("Ball"))
                    {
                        return;
                    }

                    var objectPosition = hit.collider.gameObject.transform.position;

                    // Direction from ball to hit point
                    var direction = objectPosition - Input.mousePosition;
                    direction = Vector3.Normalize(direction);

                    // horizontal direction
                    var horizontalDirection = new Vector3(direction.x, 0, direction.z);

                    // reverse direction
                    var reverseDirection = -horizontalDirection;
                    
                    
                    //TODO Click on ball and drag it to move it
                    // Get the distance from the ball to the mouse position
                    var ballToMouseDistance = objectPosition - Input.mousePosition;

                    print("Magnitude: " + ballToMouseDistance.magnitude);

                    _pushPower = (ballToMouseDistance / maxPullToPowerBallMovement).magnitude * forcePower;

                    _aimDirection = reverseDirection;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                // Move ball to mouse hit position
                _rigidbody.AddForce(_aimDirection * _pushPower, ForceMode.Impulse);
            }


            if (Input.GetKeyDown("space"))
            {
                _rigidbody.AddForce(Vector3.back * forcePower, ForceMode.Impulse);
            }
        }
    }
}