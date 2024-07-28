using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using UnityEngine;
using AudioSettings = HyperCasual.Core.AudioSettings;

namespace HyperCasual.Runner
{
    /// <summary>
    /// A simple class used to save a load values
    /// using PlayerPrefs.
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        /// <summary>
        /// Returns the SaveManager.
        /// </summary>
        public static SaveManager Instance => s_Instance;
        static SaveManager s_Instance;

        const string k_LevelProgress = "LevelProgress";
          const string k_LevelLength = "LevelLenght";
        const string k_Currency = "Currency";
        const string k_Xp = "Xp";
        const string k_AudioSettings = "AudioSettings";
        const string k_QualityLevel = "QualityLevel";

        const string k_DisplayName = "DisplayName";
        const string k_PlayFabID = "PlayFabID";

        void Awake()
        {
            s_Instance = this;
        }
        /// <summary>
        /// Save and load level progress as an integer
        /// </summary>
        // save user id and name while loggin in 
        public string DisplayName
        { 
            get => PlayerPrefs.GetString(k_DisplayName); 
            set => PlayerPrefs.SetString(k_DisplayName, value);
        }
        public string PlayFabID
        { 
            get => PlayerPrefs.GetString(k_PlayFabID); 
            set => PlayerPrefs.SetString(k_PlayFabID, value);
        }

        public int LevelProgress 
        { 
            get => PlayerPrefs.GetInt(k_LevelProgress); 
            set => PlayerPrefs.SetInt(k_LevelProgress, value);
        }

        public int LevelLength 
        { 
            get => PlayerPrefs.GetInt(k_LevelLength); 
            set => PlayerPrefs.SetInt(k_LevelLength, value);
        }

        /// <summary>
        /// Save and load currency as an integer
        /// </summary>
        public int Currency 
        { 
            get => PlayerPrefs.GetInt(k_Currency); 
            set => PlayerPrefs.SetInt(k_Currency, value);
        }

        public float XP
        {
            get => PlayerPrefs.GetFloat(k_Xp); 
            set => PlayerPrefs.SetFloat(k_Xp, value);
        }

        public bool IsQualityLevelSaved => PlayerPrefs.HasKey(k_QualityLevel);
        
        public int QualityLevel 
        { 
            get => PlayerPrefs.GetInt(k_QualityLevel); 
            set => PlayerPrefs.SetInt(k_QualityLevel, value);
        }

        public AudioSettings LoadAudioSettings()
        {
            return PlayerPrefsUtils.Read<AudioSettings>(k_AudioSettings);
        }

        public void SaveAudioSettings(AudioSettings audioSettings)
        {
            PlayerPrefsUtils.Write(k_AudioSettings, audioSettings);
        }
    }
}