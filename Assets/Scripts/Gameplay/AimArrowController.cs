using System;
using UnityEngine;

namespace Gameplay
{
    public class AimArrowController : MonoBehaviour
    {
        [SerializeField] private Transform arrowPivot;
        [SerializeField] private Transform ballPosition;
        [SerializeField] private GameObject arrow;
        [SerializeField] private BallController ballController;
        

        private void Awake()
        {
            arrowPivot.rotation = Quaternion.Euler(0, 0, 0);
            arrow.SetActive(false);
        }


        void Update()
        {
            if (ballController.IsAiming)
            {
                arrowPivot.forward = ballController.AimDirection;
                arrow.transform.localScale = new Vector3(1,1,ballController.PushPower / 10);
            }
           
            arrow.SetActive(ballController.IsAiming);
    
            arrowPivot.position = ballPosition.position;
        }
    }
}
