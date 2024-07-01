using System;
using UnityEngine;

namespace Script
{
    public class UScore : MonoBehaviour
    {
        public static int Score;

        private void Start()
        {
            Score = 0;
        }
        private void Update()
        {
         
        }

        private void OnGUI()
        {
            GUI.skin.box.fontSize = 30;
            GUI.Box(new Rect(20,20,200,50), "Score: " + Score);
            
            GUI.Box(new Rect(Screen.width - 200, 20, 200, 50),
                "Level " + UGameState.Level);
            
            if (UGameState.IsGameOver())
            {
                GUI.skin.box.fontSize = 60;
                GUI.Box(new Rect(
                    Screen.width/2 - 200,
                    Screen.height/2 - 50,
                    400,
                    100),
                    "Game Over");
            }

            if (UGameState.IsLevelComplete())
            {
                GUI.skin.box.fontSize = 40;
                GUI.Box(new Rect(
                        Screen.width/2 - 250,
                        Screen.height/2 - 50,
                        400,
                        100),
                    "Level Complete");
            }
        }
    }
}
