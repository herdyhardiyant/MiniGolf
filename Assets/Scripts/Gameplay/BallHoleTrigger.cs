using System;
using UnityEngine;

namespace Gameplay
{
    public class BallHoleTrigger : MonoBehaviour
    {
        
        public bool IsBallInHole => _isTriggered;

        private bool _isTriggered;
        

        private void Awake()
        {
            _isTriggered = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                _isTriggered = true;
            }
        }
    }
}
