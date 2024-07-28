using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using PlayFab;
using PlayFab.ClientModels;

namespace HyperCasual.Runner
{
    /// <summary>
    /// This View contains shop menu functionalities
    /// </summary>
    public class LeaderBoardScreen : View
    {
        [SerializeField]
        HyperCasualButton m_BackButton;
        //  [SerializeField]
        // HyperCasualButton m_SignUpButton;
        
      public GameObject rowPref;
      public Transform rowParent;
    // [SerializeField] public TMP_InputField  displayNameInput;
    // [SerializeField] public TMP_InputField emailInput;
    // [SerializeField] public TMP_InputField passwordInput;
        private void Start() {
           GetLeaderboard();
        }
        void OnEnable()
        {
            // m_Button.AddListener(OnButtonClick);
             m_BackButton.AddListener(OnBackButtonClicked);
            //  m_SignUpButton.AddListener(OnSignUpButtonClicked);
        }

        void OnDisable()
        {
            // m_Button.RemoveListener(OnButtonClick);
            m_BackButton.RemoveListener(OnBackButtonClicked);
            // m_SignUpButton.RemoveListener(OnSignUpButtonClicked);
        }

        void OnBackButtonClicked()
        {
            // m_BackEvent.Raise();
             UIManager.Instance.GoBack();
            //  Debug.Log("Closing signUp view");
        }
        
        void OnSignUpButtonClicked()
        {
             Debug.Log("signin Up");
            //  Register();
            // PlayFabManager.Instance.Register(displayNameInput.text, emailInput.text, passwordInput.text);
        }

   
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
        StatisticName = "readingRunnerLevel",
        // StartPosition = 0, 
        MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        // detroy the list 
        foreach (Transform item in rowParent)
        {
            Destroy(item.gameObject);
        }
        Debug.Log("successfully got leaderboard ");
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPref, rowParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();

            if (item.PlayFabId != null){
                  texts[1].text = item.DisplayName;
            } 
            else{
                  texts[1].text = item.PlayFabId.ToString();
            }
          
            texts[0].text = item.StatValue.ToString();
            
        }
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while getting leaderbaord" + error.ToString());
    }

    }
}