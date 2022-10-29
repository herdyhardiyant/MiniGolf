using Gameplay;
using UnityEngine;

namespace UIManipulators
{
    public class MousePullBallLineManipulator : MonoBehaviour
    {
        [SerializeField] private Transform ballTransform;
        [SerializeField] private LineRenderer line;
        [SerializeField] private BallController ballController;
        [SerializeField] private Camera mainCamera;


        void Update()
        {
            if (!ballController.IsAiming)
            {
                line.enabled = false;
                return;
            }

            line.enabled = true;

            DrawLineFromBallToMouseCursor();
        }

        private void DrawLineFromBallToMouseCursor()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var hitPoint = hit.point;
                line.SetPosition(0, ballTransform.position);
                line.SetPosition(1, hitPoint);
            }
        }
    }
}