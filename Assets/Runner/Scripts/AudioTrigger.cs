using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using TMPro;
using UnityEngine;


namespace HyperCasual.Runner
{

    public class AudioTrigger : MonoBehaviour   
    {
        const string k_PlayerTag = "Player";
         GameObject gate ;
        SoundID QuestionSound = SoundID.None;
  

         void Start()
         {
            gate = transform.parent.gameObject;
            TMP_Text[] gateTexts = gate.GetComponentsInChildren<TMP_Text>();
            var sound = gateTexts[2].text;                    
            QuestionSound = System.Enum.Parse<SoundID>(sound, true);
            }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_PlayerTag))
            {
                // AudioManager.Instance.PlayEffect(QuestionSound);
         
            }
    }
}
}