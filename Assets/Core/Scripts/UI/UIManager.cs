using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.Services.Core;
using Unity.Services.Authentication;
using TMPro;
using System.Threading.Tasks;
using UnityEngine;
using HyperCasual.Core;
using HyperCasual.Runner;

using PlayFab;
using PlayFab.ClientModels;

namespace HyperCasual.Core
{
    /// <summary>
    /// A singleton that manages display state and access to UI Views 
    /// </summary>
    public class UIManager : AbstractSingleton<UIManager>
    {

        [SerializeField]
        TextMeshProUGUI m_UserNameText;

        [SerializeField]
        Canvas m_Canvas;
        [SerializeField]
        RectTransform m_Root;
        [SerializeField]
        RectTransform m_BackgroundLayer;
        [SerializeField] public TextMeshProUGUI fpsText;

        [SerializeField]
        RectTransform m_ViewLayer;
        List<View> m_Views;

        View m_CurrentView;

        float fps;
        float updateTimer = 0.2f;

        

        readonly Stack<View> m_History = new ();


         void Start()
        {
       
            m_Views = m_Root.GetComponentsInChildren<View>(true).ToList();
            Init();
            
            m_ViewLayer.ResizeToSafeArea(m_Canvas);
            PlayFabManager.Instance.Login();

        }

        void Update(){
            // Debug.Log("update from ui manager");
            updateTimer -= Time.deltaTime;
            if(updateTimer <= 0f){
                fps = 1f/ Time.unscaledDeltaTime;
                fpsText.text = "FPS: " + MathF.Round(fps);
                updateTimer = 0.2f;
            }
        }



 
    void Init()
    {
        foreach (var view in m_Views)
            view.Hide();
        m_History.Clear();
    }

 public T GetView<T>() where T : View
        {
            foreach (var view in m_Views)
            {
                if (view is T tView)
                {
                    return tView;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the View of the specified type and makes it visible
        /// </summary>
        /// <param name="keepInHistory">Pushes the current View to the history stack in case we want to go back to</param>
        /// <typeparam name="T">The View class to search for</typeparam>
        public void Show<T>(bool keepInHistory = true) where T : View
        {
            foreach (var view in m_Views)
            {
                if (view is T)
                {
                    Show(view, keepInHistory);
                    break;
                }
            }
        }

        /// <summary>
        /// Makes a View visible and hides others
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="keepInHistory">Pushes the current View to the history stack in case we want to go back to</param>
        public void Show(View view, bool keepInHistory = true)
        {
            if (m_CurrentView != null)
            {
                if (keepInHistory)
                {
                    m_History.Push(m_CurrentView);
                }

                m_CurrentView.Hide();
            }

            view.Show();
            m_CurrentView = view;
        }

        /// <summary>
        /// Goes to the page visible previously
        /// </summary>
        public void GoBack()
        {
            if (m_History.Count != 0)
            {
                Show(m_History.Pop(), false);
            }
        }
    }
}