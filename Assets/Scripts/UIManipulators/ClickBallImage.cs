using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace UIManipulators
{
    public class ClickBallImage : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private RawImage aimImage;
        [SerializeField] private Transform ballTransform;
        [SerializeField] private BallController ballController;
        [SerializeField] private BallHoleTrigger ballHoleTrigger;

        // Update is called once per frame
        void Update()
        {

            if (ballHoleTrigger.IsBallInHole)
            {
                aimImage.enabled = false;
                return;
            }
            
            if (ballController.IsAiming)
            {
                SetAimBallImagePositionToMouse();
                return;
            }
            
            if (ballController.IsMoving)
            {
                aimImage.enabled = false;
                return;
            }

            TellPlayerToClickOnTheBallToShootTheBall();
        }

        private void TellPlayerToClickOnTheBallToShootTheBall()
        {
            aimImage.enabled = true;
            aimImage.transform.Rotate(0, 0, 1);
            Vector3 ballScreenPosition = camera.WorldToScreenPoint(ballTransform.position);
            aimImage.transform.position = ballScreenPosition;
        }

        private void SetAimBallImagePositionToMouse()
        {
            aimImage.enabled = true;
            Vector3 mousePosition = Input.mousePosition;
            var aimImageTransform = aimImage.transform;
            aimImageTransform.position = mousePosition;
            aimImageTransform.rotation = Quaternion.identity;
        }
    }
}