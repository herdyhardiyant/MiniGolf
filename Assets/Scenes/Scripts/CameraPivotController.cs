using UnityEngine;

namespace Scenes.Scripts
{
    public class CameraPivotController : MonoBehaviour
    {
        [SerializeField] private Transform pivotTransform;
        [SerializeField] private BallController ballController;

        
        void Update()
        {
            if (!ballController.IsMoving)
            {
                pivotTransform.position = ballController.transform.position;
            }
            
            if (ballController.Position != pivotTransform.position)
            {
                pivotTransform.position = Vector3.Lerp(pivotTransform.position, ballController.Position, Time.deltaTime * 10);
            }
            
        }
    }
}