using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using UnityEngine;

namespace HyperCasual.Runner
{
    /// <summary>
    /// Ends the game on collision, forcing a lose state.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(Collider))]
    public class Obstacle : Spawnable
    {

        SoundID m_GateFail = SoundID.None;
     

        [SerializeField]
        ParticleSystem particleSystem = null;

        SoundID m_Ouch = SoundID.Ouch;
        const string k_PlayerTag = "Player";
        
        void OnTriggerEnter(Collider col)
        {
             if(PlayerController.Instance.IsPlayerRunning == false)
               return; 
               
            if (col.CompareTag(k_PlayerTag))
            {
                // AudioManager.Instance.PlayEffect(m_GateFail);
                AudioManager.Instance.PlayEffect(m_Ouch);
                // PlayerController.Instance.AdjustSpeed(-20);
                PlayerController.Instance.CancelMovement();                
                PlayerController.Instance.FallDown();
                StartCoroutine(LoseEvent());
                Debug.Log("objstacle fail");
                particleSystem.Play();
            }
        }

        IEnumerator LoseEvent(){
            // AudioManager.Instance.PlayEffect(m_Ouch);
            yield return new WaitForSeconds(2);
            GameManager.Instance.Lose();  
        }
    }
}