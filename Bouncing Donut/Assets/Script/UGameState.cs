using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class UGameState : MonoBehaviour
    {
        private enum EGameStatus
        {
            Play = 0,
            LevelComplete,
            Over
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private static EGameStatus _state;
        public static int Level { get; private set; }

        private static void ChangeState(EGameStatus status)
        {
            _state = status;
            Debug.Log("State Changed: " + _state.ToString());
        }
        
        public static bool IsPlaying()
        {
            return _state == EGameStatus.Play;
        }
        
        public static bool IsGameOver()
        {
            return _state == EGameStatus.Over;
        }
        
        public static void ChangeToGameOver()
        {
            ChangeState(EGameStatus.Over);
        }
        
        public static bool IsLevelComplete()
        {
            return _state == EGameStatus.LevelComplete;
        }
        
        public static void ChangeToLevelComplete()
        {
            ChangeState(EGameStatus.LevelComplete);
        }
        
        public static void TryToNextLevel()
        {
            if (_state == EGameStatus.LevelComplete)
            {
                Level++;
                if (Level > 1)
                {
                    ChangeState(EGameStatus.Over);
                    return;
                }
                
                SceneManager.LoadScene("Scenes/Level" + Level);
                ChangeState(EGameStatus.Play);
            }
        }
        
        private void Start()
        {
            ChangeState(EGameStatus.Play);
            Level = 0;
        }
        
    }
}
