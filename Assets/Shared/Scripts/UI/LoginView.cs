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
    public class LoginView : View
    {
    [SerializeField]
    HyperCasualButton m_BackButton;

    [SerializeField]
    HyperCasualButton m_LoginButton;
        
    [SerializeField] public TextMeshProUGUI messageText;
    [SerializeField] public TMP_InputField emailInput;
    [SerializeField] public TMP_InputField passwordInput;

        void OnEnable()
        {
            // m_Button.AddListener(OnButtonClick);
             m_BackButton.AddListener(OnBackButtonClicked);
             m_LoginButton.AddListener(OnSignUpButtonClicked);
        }

        void OnDisable()
        {
            // m_Button.RemoveListener(OnButtonClick);
            m_BackButton.RemoveListener(OnBackButtonClicked);
            m_LoginButton.RemoveListener(OnSignUpButtonClicked);
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
            //  Login();
        }

        
    public void Login()
    {
        var request = new RegisterPlayFabUserRequest
        {
        Email = emailInput.text, 
        Password = passwordInput.text,
        RequireBothUsernameAndEmail = false
        };
          
        if (string.IsNullOrEmpty(emailInput.text))
        {
           messageText.text = "Email is required";
           return;
        }

        else if (string.IsNullOrEmpty(passwordInput.text))
        {
           messageText.text = "Password is required";
           return;
        }
        else
        {
           Debug.Log("all set ");
           PlayFabClientAPI.RegisterPlayFabUser(request, OnLoginSuccess, OnLoginError);
        }
    }

    
    void OnLoginSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("successfully registered ");
        messageText.text = "Account has been created";
        // UIManager.Instance.GoBack();
    }
    void OnLoginError(PlayFabError error)
    {
        // Debug.Log(error.GenerateErrorReport());
        Debug.Log("Error while registering" + error.ToString());
        messageText.text = error.ErrorMessage.ToString();
    }
    }
}