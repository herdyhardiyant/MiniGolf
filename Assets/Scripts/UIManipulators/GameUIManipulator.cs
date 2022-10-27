using System;
using Gameplay;
using Managers;
using TMPro;
using UnityEngine;

namespace UIManipulators
{
    public class GameUIManipulator : MonoBehaviour
    {
        [SerializeField] private TMP_Text attemptsText;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TMP_Text finalAttemptsText;
        [SerializeField] private GameObject finishPanel;
        [SerializeField] private BallHoleTrigger ballHoleTrigger;

        
        private void ShowFinishPanel()
        {
            finishPanel.SetActive(true);
            finalAttemptsText.text = "You finished the game in " + gameManager.ShotAttempts + " attempts";
        }

        private void Awake()
        {
           finishPanel.SetActive(false);
        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateAttemptsText();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAttemptsText();
            UpdateAttemptsText();

            if (ballHoleTrigger.IsBallInHole)
            {
                ShowFinishPanel();
            }
        }
        
        private void UpdateAttemptsText()
        {
            attemptsText.text = "Attempts: " + gameManager.ShotAttempts;
            finalAttemptsText.text = "Total Attempts: " + gameManager.ShotAttempts;
        }
    }
}