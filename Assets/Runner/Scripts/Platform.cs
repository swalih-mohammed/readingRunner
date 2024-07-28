using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public class Platfrom : MonoBehaviour   
    {
        // SoundID _soundId = SoundID.None;
        const string k_PlayerTag = "Player";
            //    [SerializeField]


         GameObject gate = null;

        Vector3 CollectablePos = new Vector3 (0, 0, 0);
        Vector3 GatePos = new Vector3 (0, 0, 0);
        Vector3 BoxPOS1 = new Vector3 (0, 0, 0);
        Vector3 BoxPOS2 = new Vector3 (0, 0, 0);
        Vector3 BoxPOS3 = new Vector3 (0, 0, 0);

        GameObject obstucle = null;
        GameObject collectable = null;
        GameObject box = null;
        float PlatformStartPosZ;
        float PlatformEndPosZ;
        [SerializeField] TextMeshPro questionText; 
        int randSound; 
        private string _questionText;
        TMP_Text[] texts ;
        int randQ; 
        int randO; 
        int randObstucle;

        void Start()
        {
            
            // randSound = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
            // questionText.text = randSound.ToString();

            // sounds should repate only twice
            if(LevelManager.Instance.CheckUsedSoundLen() >= LevelManager.Instance.LevelDefinition.SoundList.Length){
                LevelManager.Instance.ClearUsedSound();
                LevelManager.Instance.SetSoundRound(2); 
            }
            randQ = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);

            while (LevelManager.Instance.CheckUsedSound(randQ) == true){
                randQ = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
            }
            if(LevelManager.Instance.CheckUsedSound(randQ) == false){
                LevelManager.Instance.AddUsedSound(randQ);
            }

            // questionText.text = randQ.ToString();
             questionText.text = LevelManager.Instance.LevelDefinition.SoundList[randQ].question;

            // find z position 
            var children = transform.GetComponentsInChildren<Transform>();
            if(children.Length > 0)
                {
                foreach (var childTransform in children)
                {
                if(childTransform.tag == "PlatformStart")
                {
                PlatformStartPosZ = childTransform.transform.position.z;
                }
                if(childTransform.tag == "PlatformEnd")
                {
                PlatformEndPosZ = childTransform.transform.position.z;
                }
                }
            }

                int randDist= Random.Range(4, 6);
                float startingZCol =  PlatformStartPosZ + randDist;
                for (int i = 0; i < 3; i++)
                {
                    
                // generate three diff number for spawning
                int spawnSide1= Random.Range(0, 3);
                int spawnSide2= Random.Range(0, 3);
                int spawnSide3= Random.Range(0, 3);
                while (spawnSide2 == spawnSide1)
                {
                    spawnSide2= Random.Range(0,3);
                }
                while (spawnSide3 == spawnSide2 || spawnSide3 == spawnSide1)
                {
                    spawnSide3= Random.Range(0,3);
                }

                int side1; 
                if (spawnSide1 == 0)
                {
                    side1 = 0;
                }
                else if (spawnSide1 == 1){
                    side1 = 2; 
                } else {
                    side1 = -2;
                }

               int side2; 
                if (spawnSide2 == 0)
                {
                    side2 = 0;
                }
                else if (spawnSide2 == 1){
                    side2 = 2; 
                } else {
                    side2 = -2;
                }

                int side3; 
                if (spawnSide3 == 0)
                {
                    side3 = 0;
                }
                else if (spawnSide3 == 1){
                    side3 = 2; 
                } else {
                    side3 = -2;
                }

                 // spawn boxes 
                 box = LevelManager.Instance.LevelDefinition.Layer2Prefab;
                 
                 
                 BoxPOS3 = new Vector3 (side3, 1, startingZCol);
                
                 BoxPOS1 = new Vector3 (side1, 1, startingZCol);
                 box = Instantiate(box, BoxPOS1, Quaternion.identity);
                 box.transform.SetParent(transform);
                 texts = box.GetComponentsInChildren<TMP_Text>();
                 texts[0].text = LevelManager.Instance.LevelDefinition.SoundList[randQ].question;
                 collectable = LevelManager.Instance.LevelDefinition.Collectables[0];
                 collectable = Instantiate(collectable, BoxPOS1, Quaternion.identity);
                 collectable.transform.SetParent(transform);

                 BoxPOS2 = new Vector3 (side2, 1, startingZCol);
                 box = Instantiate(box, BoxPOS2, Quaternion.identity);
                 box.transform.SetParent(transform);
                 texts = box.GetComponentsInChildren<TMP_Text>();
                 randO = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
                    while (randO == randQ){
                        randO = Random.Range(0, LevelManager.Instance.LevelDefinition.SoundList.Length);
                    }
                    texts[0].text = LevelManager.Instance.LevelDefinition.SoundList[randO].question;
 
                 BoxPOS2 = new Vector3 (side2, 1, startingZCol);
                 randObstucle = Random.Range(0,LevelManager.Instance.LevelDefinition.Obstacles.Count ); 
                 obstucle = LevelManager.Instance.LevelDefinition.Obstacles[randObstucle];
                 obstucle = Instantiate(obstucle, BoxPOS3, Quaternion.identity);
                 obstucle.transform.SetParent(transform);


                // spawn collectible
                // int ranNumCol = Random.Range(4, 6);
                // for (int c = 0; c < ranNumCol; c++)
                // {
                //     //  while (PlatformStartPosZ + 25 < PlatformEndPosZ)
                //     //  {
                //         collectable = LevelManager.Instance.LevelDefinition.Collectables[0];
                //         CollectablePos = new Vector3 (side1, 1, startingZCol);
                //     if (collectable != null)
                //         {
                //             collectable = GameObject.Instantiate(collectable, CollectablePos, Quaternion.identity);
                //             collectable.transform.SetParent(transform);
                //             startingZCol += 2;
                //         }
                //     // }  
                // }

                // ranNumCol = Random.Range(3, 5);
                // float startingZOb =  PlatformStartPosZ + ranNumCol;
                // int ranObs ;

                //     // while (PlatformStartPosZ + 30 < PlatformEndPosZ)
                //     // {
                //         CollectablePos = new Vector3 (side2, 1, startingZOb);
                //         ranObs = Random.Range(0,LevelManager.Instance.LevelDefinition.Obstacles.Count ); 
                //         obstucle = LevelManager.Instance.LevelDefinition.Obstacles[ranObs];
                //         if (obstucle != null)
                //         {
                //             obstucle = GameObject.Instantiate(obstucle, CollectablePos, Quaternion.identity);
                //             obstucle.transform.SetParent(transform);
                //         }
                //     // }  
                    

                // ranNumCol = Random.Range(3, 5);
                // startingZOb =  PlatformStartPosZ + ranNumCol;
                // CollectablePos = new Vector3 (side3, 1, startingZOb);
                // ranObs = Random.Range(0,LevelManager.Instance.LevelDefinition.Obstacles.Count ); 
                // obstucle = LevelManager.Instance.LevelDefinition.Obstacles[ranObs];
                // if (obstucle != null)
                // {
                //     obstucle = GameObject.Instantiate(obstucle, CollectablePos, Quaternion.identity);
                //     obstucle.transform.SetParent(transform);

                // }

            startingZCol += 10;     
            }
            // spwan the gate
            gate = LevelManager.Instance.LevelDefinition.GatePrefab;
            // finishLine = LevelManager.Instance.LevelDefinition.EndPrefab;
            int UsedSoundListlen = LevelManager.Instance.CheckUsedSoundLen() ;
            int soundListLen = LevelManager.Instance.LevelDefinition.SoundList.Length;
            int soundRound = LevelManager.Instance.GetSoundRound() ; 
            // if(UsedSoundListlen >= soundListLen && soundRound >=2 ){
            //     // Debug.Log("catch the finish line");
            //     GatePos = new Vector3 (0, 0, PlatformEndPosZ);
            //     finishLine = GameObject.Instantiate(finishLine, GatePos , Quaternion.identity);
            //     finishLine.transform.SetParent(transform);
            // } 
            // else
            // {
            
            if (gate != null)
            {
                GatePos = new Vector3 (1, 3, PlatformEndPosZ);
                gate = Instantiate(gate, GatePos , Quaternion.identity);
                texts = gate.GetComponentsInChildren<TMP_Text>();
                texts[0].text = LevelManager.Instance.LevelDefinition.SoundList[randQ].question;
                texts[1].text = LevelManager.Instance.LevelDefinition.SoundList[randO].question;
                texts[2].text = LevelManager.Instance.LevelDefinition.SoundList[randQ].question;
                gate.transform.SetParent(transform);
                // PlatformStartPosZ += 5;
            }
            // }
        }

    }
}