using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual.Runner
{
   public class FootStepSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  SoundID m_footStep = SoundID.FootStep;
    void FootStepEvent (){
        // Debug.Log("footstep");
         AudioManager.Instance.PlayEffect(m_footStep);
    }

}
}
