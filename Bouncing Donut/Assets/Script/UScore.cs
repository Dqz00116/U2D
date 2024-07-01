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
            void ShowTip(int boxFontSize, string tip)
            {
                GUI.skin.box.fontSize = boxFontSize;
                GUI.Box(new Rect(Screen.width/2 - 200, Screen.height/2 - 50, 400, 100), tip);
            }
            
            GUI.skin.box.fontSize = 30;
            GUI.Box(new Rect(20,20,200,50), "Score: " + Score);
            GUI.Box(new Rect(Screen.width - 200, 20, 200, 50), "Level " + UGameState.Level);
            
            if (UGameState.IsGameOver())
            {
                ShowTip(60, "Game Over");
            }

            if (UGameState.IsLevelComplete())
            {
                ShowTip(40, "Level Complete");
            }
        }
    }
}
