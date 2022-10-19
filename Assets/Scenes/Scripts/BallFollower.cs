using UnityEngine;

namespace Scenes.Scripts
{
    public class BallFollower : MonoBehaviour
    {
        [SerializeField] private Transform pivotTransform;
        [SerializeField] private Ball ball;

        // TODO
        // Pivot for camera
        // Pivot rotate
        // Pivot follow ball with Lerp
        // Start is called before the first frame update

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            pivotTransform.position = Vector3.Lerp(pivotTransform.position, ball.Position, Time.deltaTime * 10);
        }
    }
}