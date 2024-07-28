
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Core;
using UnityEngine;


using PlayFab;
using PlayFab.ClientModels;


namespace HyperCasual.Runner
{
public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance => s_Instance;
    static PlayFabManager s_Instance;


    void Awake()
    {
        s_Instance = this;
    }
    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier, 
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true 
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("successfully logged in");
        string name = null; 
        string id = null; 
        SaveManager.Instance.DisplayName = "";
        if(result.InfoResultPayload.PlayerProfile !=null){
           
            id = result.InfoResultPayload.PlayerProfile.PlayerId;
            if(id != null){
                SaveManager.Instance.PlayFabID = id;
            }
            
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
            SaveManager.Instance.DisplayName = name;
            Debug.Log(id + "is the id and Display name is "+name );
            if(name != null){
                SaveManager.Instance.DisplayName = name;
                Debug.Log("Diplay name set to " + name);    
            }
        }
    }
    void OnLoginError(PlayFabError error)
    {
        SaveManager.Instance.DisplayName = "";
        Debug.Log(error.GenerateErrorReport());
        Debug.Log("Error while logging in");
    }

// send level progress to playfab 
    public void SendLeaderboard(int level)
    {
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate {
                    StatisticName = "readingRunnerLevel",
                    Value = level
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdateSuccess, onError);
    }
    void OnLeaderboardUpdateSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard update success ");
    }
    void onError(PlayFabError error)
    {
        Debug.Log("Leaderboard update error ");
    }
}
}