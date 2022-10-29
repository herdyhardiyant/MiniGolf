using UnityEngine;

namespace Gameplay
{
    public class BallSpawnHandler : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        [SerializeField] private Transform ballTransform;
        
        private Vector3 _spawnPosition;
        
        public void SetSpawnPoint(Vector3 spawnPoint)
        {
            _spawnPosition = spawnPoint;
        }

        void Update()
        {
            if(!ballController.IsMoving) return;
            
            if (ballTransform.position.y < -10)
            {
                ballTransform.position = _spawnPosition + Vector3.up * 2;
            }

        }
    }
}
