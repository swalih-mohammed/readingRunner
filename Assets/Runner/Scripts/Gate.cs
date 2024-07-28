using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;
using HyperCasual.Gameplay;
using UnityEngine.VFX;
using System.Linq;
// using System;
// using Codice.Client.Common.GameUI;
// using Codice.CM.WorkspaceServer.DataStore.Merge;
// using Codice.Client.Common.GameUI;


namespace HyperCasual.Runner
{
    /// <summary>
    /// A class representing a Spawnable object.
    /// If a GameObject tagged "Player" collides
    /// with this object, it will trigger a fail
    /// state with the GameManager.
    /// </summary>
    /// 
    public class Gate : MonoBehaviour
    {
        [SerializeField]  ParticleSystem particleSystemLose = null;
        [SerializeField]  ParticleSystem particleSystemWin = null;
        [SerializeField] TextMeshPro _GateRightText; 
        [SerializeField] TextMeshPro _GateLeftText; 
      
        int randQ;
        int randA;
        int TxLen;
        int fontS = 5;
        GameObject platform; 


       void Start()
        {
        // if(LevelManager.Instance.CheckUsedSoundLen() >= LevelManager.Instance.LevelDefinition.SoundList.Length){
        //     LevelManager.Instance.ClearUsedSound();
        //     LevelManager.Instance.SetSoundRound(2); 
        // }
        // randQ = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);

        //  while (LevelManager.Instance.CheckUsedSound(randQ) == true){
        //     randQ = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
        // }
        // if(LevelManager.Instance.CheckUsedSound(randQ) == false){
        //     LevelManager.Instance.AddUsedSound(randQ);
        // }

        // randA = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
        // while (randA == randQ){
        //     randA = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
        // }

        platform = transform.parent.gameObject; 
        TMP_Text[] questions = platform.GetComponentsInChildren<TMP_Text>();
        // Debug.Log("question string" +int.Parse(questions[0].text));
        TMP_Text[] texts = gameObject.GetComponentsInChildren<TMP_Text>();
        // texts[0].text = LevelManager.Instance.LevelDefinition.SoundList[randQ].question;
        // texts[1].text = LevelManager.Instance.LevelDefinition.SoundList[randA].question;
        // texts[2].text = LevelManager.Instance.LevelDefinition.SoundList[randQ].question;


        LevelManager.Instance.PrintUsedSOund();

        TxLen = texts[2].text.Length;
        // fontS =(10/ TxLen); 
        if(TxLen >= 4)
        {
         fontS = 3;
        }
         else if (TxLen == 3)
        {
          fontS = 4;
        }
        else if (TxLen == 2)
        {
          fontS = 5;
        }
        else if (TxLen == 1 )
        {
          fontS = 10;
        }
        else {
            fontS = 3;
        }
         _GateRightText.fontSize = fontS;
         _GateLeftText.fontSize = fontS;
        }
        }
    }

