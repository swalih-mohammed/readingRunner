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
    public class PlatfromExit : MonoBehaviour   
    {
        // SoundID _soundId = SoundID.None;
        const string k_PlayerTag = "Player";
            //    [SerializeField]
   
    
         Vector3 GatePosition = new Vector3 (0, 0, 0);
         Vector3 L1Position = new Vector3 (0, 0, 0);
  
         
         GameObject go = null;
        GameObject platform = null;
         GameObject l1 = null;
        float NextGatePosition;
        float LayerStarPosition = 0 ;
        float LayerEndPosition = 0 ;
        Vector3 CollectablePos = new Vector3 (0, 0, 0);
        Vector3 GatePos = new Vector3 (0, 0, 0);

        GameObject obstucle = null;
        GameObject collectable = null;

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_PlayerTag)){
                // Debug.Log("Entering");
               
                // GameObject test = transform.parent.gameObject;
                // NextGatePosition = test.transform.position.z+100;
                // GatePosition = new Vector3 (-4, -1, NextGatePosition);
                // if (test != null){
                //   platform = GameObject.Instantiate(test, GatePosition , Quaternion.identity) ;
                // }
                // platform.transform.SetParent(test.transform.parent.gameObject.transform);
                // spwan the gate
                // GameObject gate = LevelManager.Instance.LevelDefinition.GatePrefab;
                // if (gate != null){
                //     GatePos = new Vector3 (1, 3, NextGatePosition + 30);
                //     gate = GameObject.Instantiate(gate, GatePos , Quaternion.identity) ;
                // }
              
                // spwan the collectables 
                    //     for (int i = 0; i < 2; i ++)
                    //     {
                            
                    //     int spawnSide = Random.Range(0, 3);
                    //     int side = 0; 
                    //     if (spawnSide == 0)
                    //     {
                    //         side = -2;
                    //     }
                    //      else if (spawnSide == 0){
                    //         side = 0; 
                    //     } else {
                    //         side = 2;
                    //     }

                    //     int randDist = Random.Range(2, 5); 
                    //      NextGatePosition = NextGatePosition + randDist; 
                    //     int ranNumCol = Random.Range(7, 15); 
                    //     for (int c = 0; c < ranNumCol; c++)
                    //     {
                    //      CollectablePos = new Vector3 (side, 1, NextGatePosition);
                    //      collectable = GameObject.Instantiate(LevelManager.Instance.LevelDefinition.Collectables[0], CollectablePos, Quaternion.Euler(eulerAngles));
                    //       NextGatePosition += 2; 
                    //     }
                    // }

                // NextGatePosition += 50;
            }
        }
        void OnTriggerExit(Collider col)
        {
                            // Debug.Log("Exiting");


            if (col.CompareTag(k_PlayerTag)){
                // Debug.Log("Exiting");
                Destroy(transform.parent.gameObject);
            }
            // if (col.CompareTag(k_PlayerTag))
            // {
            // GameObject gate = transform.parent.gameObject;
            // TMP_Text[] questionTexs = gate.GetComponentsInChildren<TMP_Text>();
            // var sound = questionTexs[2].text; 
            // SoundID QuestionSound = System.Enum.Parse<SoundID>(sound, true); // ignore cases
            // AudioManager.Instance.PlaySound(QuestionSound);

            // // set next gate
            // NextGatePosition = Random.Range(40, 50); 
            // GameObject goParent = transform.parent.gameObject.transform.gameObject;
            // GatePosition = new Vector3 (1, 3,  goParent.transform.position.z + NextGatePosition) ;
            // gate = LevelManager.Instance.LevelDefinition.GatePrefab;
            // gate = GameObject.Instantiate(gate, GatePosition, Quaternion.identity) ;
            // // Debug.Log("" + gate.name) ;
            
            // // set spawns around
            // LayerStarPosition = goParent.transform.position.z;
            // LayerEndPosition =  goParent.transform.position.z + NextGatePosition;
            // Debug.Log("start" + LayerStarPosition + "end" + LayerEndPosition);
            // for (int i = (int)LayerStarPosition; i < LayerEndPosition; i+=2)
            // {
            //     Debug.Log("i" + i + "z" + LayerStarPosition);
            //      go = LevelManager.Instance.LevelDefinition.Layer1Prefab;
            //      L1Position = new Vector3 (4.5f, 0,  LayerStarPosition) ;
            //      go = GameObject.Instantiate(go, L1Position, Quaternion.identity) ;
            //      go.transform.SetParent(gate.transform);
            //      L1Position = new Vector3 (-4.5f, 0,  LayerStarPosition) ;
            //      go = GameObject.Instantiate(go, L1Position, Quaternion.identity) ;
            //      go.transform.SetParent(gate.transform);

            //      go = LevelManager.Instance.LevelDefinition.Layer2Prefab;
            //      L1Position = new Vector3 (5.5f, 1.5f,  LayerStarPosition) ;
            //      go = GameObject.Instantiate(go, L1Position, Quaternion.identity) ;
            //      go.transform.SetParent(gate.transform);
            //      L1Position = new Vector3 (-5.5f, 1.5f,  LayerStarPosition) ;
            //      go = GameObject.Instantiate(go, L1Position, Quaternion.identity) ;
            //      go.transform.SetParent(gate.transform);

            //     if (i % 5 == 0)
            //     {
            //      go = LevelManager.Instance.LevelDefinition.Layer3Prefab;
            //      L1Position = new Vector3 (7, 1,  LayerStarPosition) ;
            //      go = GameObject.Instantiate(go, L1Position, Quaternion.identity) ;
            //      go.transform.SetParent(gate.transform);
            //      L1Position = new Vector3 (-7 , 1,  LayerStarPosition) ;
            //      go = GameObject.Instantiate(go, L1Position, Quaternion.identity) ;
            //      go.transform.SetParent(gate.transform);
            //     }
            //      LayerStarPosition += 2; 
            // }
         
            // }
        }
    }
}