using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class UTitleMenu : MonoBehaviour
    {
        [Header("Config")]
        public string gameScene = "Scenes/Game";

        private void Start()
        {
        
        }

        private void Update()
        {
        
        }

        public void PlayGame()
        {
            Debug.Log("PlayGame Clicked.");
            SceneManager.LoadScene(gameScene);
        }

        public void ExitGame()
        {
            Debug.Log("ExitGame Clicked.");
            Application.Quit();
        }
    }
}
