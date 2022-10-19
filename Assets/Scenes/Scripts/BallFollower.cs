using UnityEngine;

namespace Scenes.Scripts
{
    public class BallFollower : MonoBehaviour
    {
        [SerializeField] private Transform pivotTransform;
        [SerializeField] private Ball ball;

        // TODO
        // Pivot follow ball with Lerp

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