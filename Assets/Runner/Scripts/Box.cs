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

    public class Box : MonoBehaviour
    {

        SoundID m_GateFail = SoundID.None;
        SoundID GateSuccess = SoundID.GateSuccess;

        [SerializeField]
        ParticleSystem particleSystem = null;

        SoundID m_Ouch = SoundID.Ouch;
        const string k_PlayerTag = "Player";
        
        void OnTriggerEnter(Collider col)
        {               
            if (col.CompareTag(k_PlayerTag))
            {
                Destroy(gameObject);           
            }
        }
    }
}