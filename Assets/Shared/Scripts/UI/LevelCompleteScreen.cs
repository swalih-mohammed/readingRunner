using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using TMPro;

using UnityEngine.UI;

using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using Random = UnityEngine.Random;
using UnityEngine;

namespace HyperCasual.Runner
{
    /// <summary>
    /// This View contains celebration screen functionalities
    /// </summary>
    public class LevelCompleteScreen : View
    {
        [SerializeField]
        HyperCasualButton m_NextButton;
        [SerializeField]
        Image[] m_Stars;
        [SerializeField]
        AbstractGameEvent m_NextLevelEvent;
       
         [SerializeField] TextMeshProUGUI m_TempGoldText;
        [SerializeField] TextMeshProUGUI m_TotalGoldText;
        [SerializeField] TextMeshProUGUI m_CompletedLevelText;
        [SerializeField] Slider m_XpSlider;
        [SerializeField] private float m_cycleLength = 2; 
     


    
        
        /// <summary>
        /// The slider that displays the XP value 
        /// </summary>

        public Slider XpSlider => m_XpSlider;

        int m_TotalGoldValue;
         int m_TempGoldValue;
        int m_CurrentLevel;
        const string k_LevelProgress = "LevelProgress";
        
        /// <summary>
        /// The amount of gold to display on the celebration screen.
        /// The setter method also sets the celebration screen text.
        /// </summary>
        /// 


        public int TotalGoldValue
        {
            get => m_TotalGoldValue;
            set
            {
                if (m_TotalGoldValue != value)
                {
                    m_TotalGoldValue = value;
                    m_TotalGoldText.text = TotalGoldValue.ToString();

                }
            }
        }

        public int TempGoldValue
        {
            get => m_TempGoldValue;
            set
            {
                if (m_TempGoldValue != value)
                {
                    m_TempGoldValue = value;
                    m_TempGoldText.text = TempGoldValue.ToString();

                }
            }
        }

        public int ShowComlpetedLevel
        {
         get => m_CurrentLevel;
         set
            {

                if (m_CurrentLevel != value)
                {
                    m_CurrentLevel = value;
                    m_CompletedLevelText.text = ShowComlpetedLevel.ToString();
                }
      
            }

        }
        
    public int ShowTempGold
        {
         get => m_CurrentLevel;
         set
            {

                if (m_CurrentLevel != value)
                {
                    m_CurrentLevel = value;
                    m_CompletedLevelText.text = ShowComlpetedLevel.ToString();
                }
      
            }

        }

        float m_XpValue;
        
        /// <summary>
        /// The amount of XP to display on the celebration screen.
        /// The setter method also sets the celebration screen slider value.
        /// </summary>
        public float XpValue
        {
            get => m_XpValue;
            set
            {
                if (!Mathf.Approximately(m_XpValue, value))
                {
                    m_XpValue = value;
                    // m_XpSlider.value = m_XpValue;
                }
            }
        }

        int m_StarCount = -1;
        
        /// <summary>
        /// The number of stars to display on the celebration screen.
        /// </summary>
        public int StarCount
        {
            get => m_StarCount;
            set
            {
                if (m_StarCount != value)
                {
                    m_StarCount = value;
                    DisplayStars(m_StarCount);
                }
            }
        }

        void OnEnable()
        {
            m_NextButton.AddListener(OnNextButtonClicked);
        }

        void OnDisable()
        {
            m_NextButton.RemoveListener(OnNextButtonClicked);
        }

        void OnNextButtonClicked()
        {
            m_NextLevelEvent.Raise();
        }

        void DisplayStars(int count)
        {
            count = Mathf.Clamp(count, 0, m_Stars.Length);

            if (m_Stars.Length > 0 && count >= 0 && count <= m_Stars.Length)
            {
                for (int i = 0; i < m_Stars.Length; i++)
                {
                    m_Stars[i].gameObject.SetActive(i < count);
                }
            }
        }
    



}

}
