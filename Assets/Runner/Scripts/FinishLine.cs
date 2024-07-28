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
    public class FinishLine : Spawnable
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
                Debug.Log("win even t");
                StartCoroutine(WonEvent());
              

            }
        }
       IEnumerator WonEvent()
       {
        yield return new WaitForSeconds(2);
        Debug.Log("win even t");
        GameManager.Instance.Win();  
        }
    }
     
}