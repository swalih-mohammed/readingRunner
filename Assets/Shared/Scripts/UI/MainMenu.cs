using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using UnityEngine;

// using UnityEngine.SocialPlatforms;
using System;
using UnityEngine.UI;
using TMPro;
// using System.Threading.Tasks;

// using Unity.Services.Authentication;
// using Unity.Services.Core;


namespace HyperCasual.Runner
{
    /// <summary>
    /// This View contains main menu functionalities
    /// </summary>
    public class MainMenu : View
    {
        [SerializeField]  HyperCasualButton m_StartButton;
        [SerializeField] HyperCasualButton m_SettingsButton;
         [SerializeField] HyperCasualButton m_LeaderButton;
        [SerializeField] HyperCasualButton m_LoginButton;

        [SerializeField] HyperCasualButton m_TestButton;

        [SerializeField]
        AbstractGameEvent m_StartButtonEvent;

        [SerializeField]
        TextMeshProUGUI m_UserNameText;
        string displayName;
        [SerializeField] TextMeshProUGUI m_LevelProgressText;
        [SerializeField] TextMeshProUGUI m_LevelTotalText;
        [SerializeField] TextMeshProUGUI m_TotalGoldText;
         [SerializeField] public Slider m_LevelProgressSlider;
        int levelProgress;
        string levelPrgressText;
        int LevelLenght;
        string levelLenghtText;

        float levelLenghtPercent;
        int m_GoldValue;
        // coin
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private Transform coinParent;

    [SerializeField] private Transform spawnLocation;

    [SerializeField] private Transform endPosition;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private float duration;
    [SerializeField] private int coinAmount;

    [SerializeField] private float minX;

    [SerializeField] private float maxX;

    [SerializeField] private float minY;

    [SerializeField] private float maxY;
    
    List<GameObject> coins = new List<GameObject>();


        void Start(){
            displayName = SaveManager.Instance.DisplayName;
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

              m_TotalGoldText.text= SaveManager.Instance.Currency.ToString();
            
        }

        public int GoldValue
        {
            get => m_GoldValue;
            set
            {
                if (m_GoldValue != value)
                {
                    m_GoldValue = value;
                    m_TotalGoldText.text = GoldValue.ToString();
                }
            }
        }

     
        void OnEnable()
        {
            m_StartButton.AddListener(OnStartButtonClick);
            m_SettingsButton.AddListener(OnSettingsButtonClick);
            m_LeaderButton.AddListener(OnLeaderButtonClick);
            m_LoginButton.AddListener(OnLoginButtonClick);
            m_TestButton.AddListener(OnTestButtonClick);
        }
        
        void OnDisable()
        {
            m_StartButton.RemoveListener(OnStartButtonClick);
            m_SettingsButton.RemoveListener(OnSettingsButtonClick);
            m_LeaderButton.RemoveListener(OnLeaderButtonClick);
            m_LoginButton.RemoveListener(OnLoginButtonClick);
            m_TestButton.RemoveListener(OnTestButtonClick);
        }
      void OnTestButtonClick()
        {
            // m_StartButtonEvent.Raise();
            // AudioManager.Instance.PlayEffect(SoundID.ButtonSound);
              UIManager.Instance.Show<SettingsMenu>();
              Debug.Log("test click");
        }
        void OnStartButtonClick()
        {
            m_StartButtonEvent.Raise();
            AudioManager.Instance.PlayEffect(SoundID.ButtonSound);
        }

        void OnSettingsButtonClick()
        {
            Debug.Log("seeting click");
            // UIManager.Instance.Show<SettingsMenu>();
            AudioManager.Instance.PlayEffect(SoundID.ButtonSound);
            //  UIManager.Instance.Show<SignUpView>();
        }

         void OnLeaderButtonClick()
        {
            Debug.Log("leader click");
            AudioManager.Instance.PlayEffect(SoundID.ButtonSound);
            // UIManager.Instance.Show<LeaderBoardScreen>();
            //  UIManager.Instance.Show<SignUpView>();
              if (SaveManager.Instance.DisplayName == "" || SaveManager.Instance.DisplayName == null){
                 UIManager.Instance.Show<DisplayNameView>();
            } else {
                 UIManager.Instance.Show<LeaderBoardScreen>(); 
            }
    
        }
         void OnLoginButtonClick()
        {
            // Debug.Log("user prof click");
            AudioManager.Instance.PlayEffect(SoundID.ButtonSound);
            if (SaveManager.Instance.DisplayName == "" || SaveManager.Instance.DisplayName == null){
                 UIManager.Instance.Show<DisplayNameView>();
            } else {
                 UIManager.Instance.Show<ProfileView>(); 
                    
            }
            // UIManager.Instance.Show<ProfileView>(); 
           
        }
    }
}