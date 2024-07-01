using System;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class UDonut : MonoBehaviour
    {
        public Rigidbody2D rigidBody;

        private float _levelCompleteTimer;
        
        private void Start()
        {
            _levelCompleteTimer = 5.0f;
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (UGameState.IsLevelComplete())
            {
                // gameObject.SetActive(false);
                rigidBody.velocity = Vector2.zero;
                _levelCompleteTimer -= Time.deltaTime;
                if (_levelCompleteTimer < 0.0f)
                {
                    UGameState.TryToNextLevel();
                }
            }

            if (UGameState.IsPlaying())
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
                transform.position += movement * 5 * Time.deltaTime;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var parentObject = other.gameObject.transform.parent;

            if (!UGameState.IsPlaying())
                return;

            if (other.gameObject.name == "WoodPlank")
            {
                UScore.Score += 10;
            }
            else if (parentObject != null && parentObject.name == "Box")
            {
                UScore.Score += 100;
                UGameState.ChangeToLevelComplete();
            }
        }
    }
}