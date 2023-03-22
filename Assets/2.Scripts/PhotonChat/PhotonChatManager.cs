using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    ChatClient chatClinet;
    [SerializeField] string userID;
    bool isConnected;
    string chatChannelName = "OJT";

    private void Start()
    {
        ChatConnect();  
    }

    public void ChatConnect()
    {
        isConnected = true;

        chatClinet = new ChatClient(this);

        string appID = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat;
        string appVersion = PhotonNetwork.AppVersion;
        AuthenticationValues authValues = new AuthenticationValues(PhotonNetwork.NickName);
        chatClinet.Connect(appID, appVersion, authValues);
    }
    private void Update()
    {
        // 필요한가?
        if(isConnected)
        {
            chatClinet.Service();
        }
       
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        Debug.Log("OnConnected");
        // photonchat 서버와 연결
        isConnected = true;
        chatClinet.Subscribe(chatChannelName);
    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }
}
