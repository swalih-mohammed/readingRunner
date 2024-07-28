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
    public class ProfileView : View
    {
   
        [SerializeField] HyperCasualButton m_BackButton;
        [SerializeField] TextMeshProUGUI m_UserNameText;
        [SerializeField] TextMeshProUGUI m_UserIDText;
        [SerializeField] TextMeshProUGUI m_LevelProgressText;
        [SerializeField] TextMeshProUGUI m_LevelTotalText;
         [SerializeField] public Slider m_LevelProgressSlider;
        [SerializeField] public TextMeshProUGUI messageText;
        int levelProgress;
        string levelPrgressText;
        int LevelLenght;
        string levelLenghtText;
        string displayName;
        string userID;
        float levelLenghtPercent;
    

        void Start(){

            displayName = SaveManager.Instance.DisplayName;
            userID = SaveManager.Instance.PlayFabID;
            if (userID != null ){
                 m_UserIDText.text = "ID: " +  userID;
            } 

            if(displayName != ""){
                Debug.Log("diplayName" + displayName);
                m_UserNameText.text = displayName;
            } else{
                m_UserNameText.text = "No Name";
            }

              levelProgress = SaveManager.Instance.LevelProgress;
              levelPrgressText =levelProgress.ToString();
              m_LevelProgressText.text = levelPrgressText;

              LevelLenght = SaveManager.Instance.LevelLength;
              levelLenghtText =LevelLenght.ToString();
              m_LevelProgressText.text = levelLenghtText;
              m_LevelTotalText.text = levelPrgressText + "/" + levelLenghtText;

              
              float levelProgressPercent = levelProgress;
              levelLenghtPercent = levelProgressPercent/LevelLenght;
            //   Debug.Log("progress" + levelProgress +" "+ LevelLenght +" "+ levelLenghtPercent);
              m_LevelProgressSlider.value = levelLenghtPercent;
            
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

           }
}