using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using HyperCasual.Runner;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual.Gameplay
{
    /// <summary>
    /// This View contains head-up-display functionalities
    /// </summary>
    public class Hud : View
    {
        [SerializeField]
        TextMeshProUGUI m_GoldText;

         [SerializeField]
        TextMeshProUGUI m_LevelText;

        [SerializeField]
        Slider m_XpSlider;
        [SerializeField]
        HyperCasualButton m_PauseButton;
        [SerializeField]
        AbstractGameEvent m_PauseEvent;

        /// <summary>
        /// The slider that displays the XP value 
        /// </summary>
        public Slider XpSlider => m_XpSlider;

        int m_GoldValue;

        int m_CurrentLevel;
        
        /// <summary>
        /// The amount of gold to display on the hud.
        /// The setter method also sets the hud text.
        /// </summary>
        /// 
        void Start()
        {
            // Debug.Log("123");
            m_CurrentLevel = LevelManager.Instance.LevelDefinition.LevelNum;
            // Debug.Log("123" +m_CurrentLevel);
            m_LevelText.text = m_CurrentLevel.ToString();
            // m_LevelText.text = "100";

        }

          void Update()
        {
            // Debug.Log("123");
            m_CurrentLevel = LevelManager.Instance.LevelDefinition.LevelNum;
            // Debug.Log("123" +m_CurrentLevel);
            // m_LevelText.text = m_CurrentLevel.ToString();

        }

    
        public int CurrentLevel
        {
            // Debug.Log("c level");
            get => m_CurrentLevel;
            set
            {
                if (m_CurrentLevel != value)
                {
                    m_CurrentLevel = value;
                    m_LevelText.text = CurrentLevel.ToString();
                }
            }
        }
        public int GoldValue
        {
            // Debug.Log("c level");
            get => m_GoldValue;
            set
            {
                if (m_GoldValue != value)
                {
                    m_GoldValue = value;
                    m_GoldText.text = GoldValue.ToString();
                }
            }
        }

        float m_XpValue;
        
        /// <summary>
        /// The amount of XP to display on the hud.
        /// The setter method also sets the hud slider value.
        /// </summary>
        public float XpValue
        {
            get => m_XpValue;
            set
            {
                if (!Mathf.Approximately(m_XpValue, value))
                {
                    m_XpValue = value;
                    m_XpSlider.value = m_XpValue;
                }
            }
        }

    public int showCurrentLevel
        {
        // Debug.Log("c level" + LevelManager.Instance.LevelDefinition.LevelNum);
         get => m_CurrentLevel;
         set
            {

                if (m_CurrentLevel != value)
                {
                    m_CurrentLevel = value;
                    m_GoldText.text = showCurrentLevel.ToString();
                    Debug.Log("c level" );
                }
      
            }

        }

        void OnEnable()
        {
            m_PauseButton.AddListener(OnPauseButtonClick);
        }

        void OnDisable()
        {
            m_PauseButton.RemoveListener(OnPauseButtonClick);
        }

        void OnPauseButtonClick()
        {
            m_PauseEvent.Raise();
        }
    }
}
