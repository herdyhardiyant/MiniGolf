using UnityEngine;

namespace Scenes.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform cameraPivot;
        [SerializeField] private float cameraSensitive = 1f;
        [SerializeField] private new Camera camera;
        Vector3 _lastMousePosition;
        [SerializeField] private Ball ball;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var delta = Input.mousePosition - _lastMousePosition;
                Transform cameraTransform = camera.transform;
                Transform pivotTransform = cameraPivot.transform;
                
                pivotTransform.RotateAround(ball.Position, Vector3.up, delta.x * cameraSensitive);
                pivotTransform.RotateAround(ball.Position, pivotTransform.right, delta.y * cameraSensitive);

                var angle = Vector3.SignedAngle(Vector3.up, cameraTransform.up, cameraTransform.right);
                
                if (angle < 3)
                    pivotTransform.RotateAround(ball.Position, cameraTransform.right, 3 - angle);
                else
                {
                    if (angle > 65)
                        pivotTransform.RotateAround(ball.Position, cameraTransform.right, 65 - angle);
                }
                
            }

            _lastMousePosition = Input.mousePosition;
        }
    }
}
