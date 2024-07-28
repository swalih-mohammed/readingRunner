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
    public class DisplayNameView : View
    {
    [SerializeField]
    HyperCasualButton m_BackButton;

    [SerializeField]
    HyperCasualButton m_SubmiButton;
        
    [SerializeField] public TextMeshProUGUI errorText;
    [SerializeField] public TMP_InputField nameInput;

        void OnEnable()
        {
             m_BackButton.AddListener(OnBackButtonClicked);
             m_SubmiButton.AddListener(OnSubmitButtonClicked);
        }

        void OnDisable()
        {
            m_BackButton.RemoveListener(OnBackButtonClicked);
            m_SubmiButton.RemoveListener(OnSubmitButtonClicked);
        }

        void OnBackButtonClicked()
        {
            // m_BackEvent.Raise();
             UIManager.Instance.GoBack();
            //  Debug.Log("Closing signUp view");
        }
        
        void OnSubmitButtonClicked()
        {
             Debug.Log("SubmitName Up");
             SubmitName();
        }

        
    public void SubmitName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
        DisplayName = nameInput.text, 
        };
          
        if (string.IsNullOrEmpty(nameInput.text))
        {
           errorText.text = "Add A Display Name";
           return;
        }

        else if (nameInput.text == "King")
        {
           errorText.text = "Add A Valid Display Name";
           return;
        }
        else
        {
           Debug.Log("all set ");
           PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        }
    }

    
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("successfully registered ");
        errorText.text = "Account has been created";
        PlayFabManager.Instance.Login();
        // UIManager.Instance.GoBack();
        UIManager.Instance.Show<MainMenu>();
        
    }
    void OnError(PlayFabError error)
    {
        // Debug.Log(error.GenerateErrorReport());
        Debug.Log("Error while registering" + error.ToString());
        errorText.text = error.ErrorMessage.ToString();
    }
    }
}