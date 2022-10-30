using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadLevel(int levelIndex)
        {
            SceneManager.LoadSceneAsync("Gameplay");
            SceneManager.LoadSceneAsync("Level" + levelIndex, LoadSceneMode.Additive);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}