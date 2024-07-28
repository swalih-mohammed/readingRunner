using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using TMPro;
using UnityEngine;


namespace HyperCasual.Runner
{
    /// <summary>
    /// Ends the game on collision, forcing a win state.
    /// </summary>
    /// 


    // [ExecuteInEditMode]
    // [RequireComponent(typeof(Collider))]
    public class PlatfromEntry : MonoBehaviour   
    {
        // SoundID _soundId = SoundID.None;
        const string k_PlayerTag = "Player";
            //    [SerializeField]
   
        GameObject platform = null;
        
        Transform parent;
        GameObject gate = null;
        GameObject obstucle = null;
        GameObject collectable = null;
        float PlatformPosition;
        float StartPosition =30;
        Vector3 PlatformPOS = new Vector3 (0, 0, 0);
        Vector3 GatePos = new Vector3 (0, 0, 0);
        Vector3 CollectablePos = new Vector3 (0, 0, 0);
        SoundID QuestionSound = SoundID.None;
        string soundText;
        int soundIndex; 

          void Start()
         {
            gate = transform.parent.gameObject;
            TMP_Text[] gateTexts = gate.GetComponentsInChildren<TMP_Text>();
            soundText = gateTexts[0].text; 
            Debug.Log("text " + soundText);
            // soundIndex = int.Parse (soundText);
            // soundText = LevelManager.Instance.LevelDefinition.SoundList[0].question;
            QuestionSound = System.Enum.Parse<SoundID>(soundText, true);

            }
        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_PlayerTag))
            {
                 // spwan the platform
                PlayerController.Instance.AdjustSpeed(-2);
                AudioManager.Instance.PlaySound(QuestionSound);
                // Debug.Log("q text " + soundText);
                parent = transform.parent.transform;
                PlatformPosition = parent.position.z + 64;
                PlatformPOS = new Vector3 (0, 0, PlatformPosition);
                platform = LevelManager.Instance.LevelDefinition.Layer1Prefab;
                if (platform != null){
                  platform = GameObject.Instantiate(platform, PlatformPOS , Quaternion.identity) ;
                  platform.transform.SetParent(parent.transform.parent.transform);
                
                }
            }
        }
           void OnTriggerExit(Collider col)
        {
            if (col.CompareTag(k_PlayerTag))
            {
                 // spwan the platform
                AudioManager.Instance.PlaySound(QuestionSound);
                PlayerController.Instance.AdjustSpeed(2);

             
            }
        }
    
    }
}