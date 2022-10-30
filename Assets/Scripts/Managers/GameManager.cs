using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public int ShotAttempts => _shotAttempts;
        

        private int _shotAttempts;
        
        public void IncrementShotAttempts()
        {
            _shotAttempts++;
        }

        private void Awake()
        {
            _shotAttempts = 0;
        }

     
    }
}