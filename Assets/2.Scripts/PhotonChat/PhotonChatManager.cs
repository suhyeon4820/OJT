using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using System;
public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    public Action<string, string> ReturnChatInputAction;

    protected internal ChatAppSettings chatAppSettings;

    ChatClient chatClient;
    [SerializeField] string userID;
    
    string chatChannelName = "OJT";

 
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
        Connect();


    }

    private void OnApplicationQuit()
    {
        if(chatClient!=null)
        {
            chatClient.Disconnect();
        }
    }

    public void Connect()
    {
        chatClient = new ChatClient(this);
        string appID = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat;
        string appVersion = PhotonNetwork.AppVersion;
        AuthenticationValues authValues = new AuthenticationValues(PhotonNetwork.NickName);
        chatClient.Connect(appID, appVersion, authValues);

    }

 
    private void Update()
    {
        // 필요한가?
        if(chatClient!=null)
        {
            chatClient.Service();
        }
    }

    #region 메세지 보내기
    public void SendInputMessage(string message)
    {
        chatClient.PublishMessage(chatChannelName, message);
    }
    #endregion

    #region photonchat 연결 및 구독
    public void DebugReturn(DebugLevel level, string message)
    {
        if (level == DebugLevel.ERROR)
        {
            Debug.LogError(message);
        }
        else if (level == DebugLevel.WARNING)
        {
            Debug.LogWarning(message);
        }
        else
        {
            Debug.Log(message);
        }
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state); // 현재 클라이언트의 상태를 출력
    }
    //  서버와 연결되면 호출
    public void OnConnected()
    {
        chatClient.Subscribe(chatChannelName); // 채널명으로 접속
    }

    public void OnDisconnected()
    {
        Debug.Log("OnDisconnected");
    }
    // Update() 의 chatClient.Service() 가 매 호출 시 OnGetMessages 를 호출
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        if(channelName == chatChannelName)
        {
            Debug.Log(channelName + senders[0] + messages[0]);
            ReturnChatInputAction?.Invoke(senders[0].ToString(), messages[0].ToString());
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log(string.Format("채널 입장 {0} : {1}", channels[0], results[0]));
        //throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log(string.Format("채널 퇴장 {0}", channels));
        //throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
