using System;
using UnityEngine;

namespace Script
{
    public class UWoodPlank : MonoBehaviour
    {
        private void Update()
        {
            if (!UGameState.IsPlaying()) return;

            if (Input.GetKey("w"))
            {
                // Debug.Log("OnWKeyDown");
                transform.Translate(0, 5 * Time.deltaTime, 0);
            }
            else if (Input.GetKey("s"))
            {
                // Debug.Log("OnSKeyDown");
                transform.Translate(0, -5 * Time.deltaTime, 0);
            }
        }
    }
}