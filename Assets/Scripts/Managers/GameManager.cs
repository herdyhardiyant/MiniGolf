using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public int ShotAttempts => _shotAttempts;
        

        private int _shotAttempts;

        // TODO is ball enter the hole
        // TODO is ball out of bounds
        // TODO ball respawn position
        // TODO Count shot attempts
        

        public void IncrementShotAttempts()
        {
            _shotAttempts++;
        }

        private void Awake()
        {
            _shotAttempts = 0;
        }

        void Start()
        {
        
        }
    
        void Update()
        {
        
        }
    }
}