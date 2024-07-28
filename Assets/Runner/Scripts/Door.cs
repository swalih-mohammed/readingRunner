using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using TMPro;
using UnityEngine;

namespace HyperCasual.Runner
{
    /// <summary>
    /// Ends the game on collision, forcing a lose state.
    /// </summary>

    public class Door : MonoBehaviour
    {

        SoundID m_GateFail = SoundID.None;
        SoundID GateSuccess = SoundID.GateSuccess;

        [SerializeField]
        ParticleSystem particleSystem = null;

        SoundID m_Ouch = SoundID.Ouch;
        const string k_PlayerTag = "Player";
        
        void OnTriggerEnter(Collider col)
        {
            //  if(PlayerController.Instance.IsPlayerRunning == false)
            //    return; 
               
            if (col.CompareTag(k_PlayerTag))
            {
   
                GameObject go = transform.parent.gameObject.transform.parent.gameObject;
                TMP_Text[] questionTexs = go.GetComponentsInChildren<TMP_Text>();
                TMP_Text[] gateTexts = GetComponentsInChildren<TMP_Text>();
                bool scored = questionTexs[2].text == gateTexts[0].text;

                if (scored == true)
                {
                // Debug.Log("Correct");
                //  particleSystemWin.Play();
                //  AudioManager.Instance.PlayEffect(_soundId);
                
                // var sound = questionTexs[2].text;                    
                // SoundID QuestionSound = System.Enum.Parse<SoundID>(sound, true); // ignore cases
                AudioManager.Instance.PlayEffect(GateSuccess);
                //  PlayerController.Instance.AdjustSpeed(2);
                 Destroy(gameObject);
               } 
            else
              {
                // particleSystemLose.Play();
                // AudioManager.Instance.PlayEffect(m_GateFail);
                AudioManager.Instance.PlayEffect(m_Ouch);
                PlayerController.Instance.AdjustSpeed(-20);
                PlayerController.Instance.CancelMovement();                
                PlayerController.Instance.FallDown();
                StartCoroutine(LoseEvent());

                }                
            }
        }

        IEnumerator LoseEvent(){
            // AudioManager.Instance.PlayEffect(m_Ouch);
            yield return new WaitForSeconds(2);
            GameManager.Instance.Lose();  
        }
    }
}