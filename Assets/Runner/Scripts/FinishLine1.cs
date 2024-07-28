using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using UnityEngine;

namespace HyperCasual.Runner
{
    /// <summary>
    /// Ends the game on collision, forcing a win state.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(Collider))]
    public class FinishLine1 : MonoBehaviour
    {
        const string k_PlayerTag = "Player";
        [SerializeField]
        SoundID m_level_completeSound = SoundID.None;
        
        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_PlayerTag))
            {
                AudioManager.Instance.PlayEffect(m_level_completeSound);
                 PlayerController.Instance.AdjustSpeed(-20);
                 PlayerController.Instance.IsWaving();
                Debug.Log("win even start");
                StartCoroutine(WonEvent());
              

            }
        }
       IEnumerator WonEvent()
       {
                        Debug.Log("win even midle");

        yield return new WaitForSeconds(2);
      
        GameManager.Instance.Win();  
          Debug.Log("wind end");
        }
    }
     
}