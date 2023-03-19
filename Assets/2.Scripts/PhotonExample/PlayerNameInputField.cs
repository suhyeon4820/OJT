using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Collections;
public class PlayerNameInputField : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";

    private void Start()
    {
        string defaultName = string.Empty;
        TMP_InputField inputField = this.GetComponent<TMP_InputField>();
        if(inputField!=null)
        {
            if(PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                inputField.text = defaultName;
            }
        }
        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName(TMP_InputField value)
    {
        Debug.Log(value.ToString());
        if(string.IsNullOrEmpty(value.text))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value.text;
        PlayerPrefs.SetString(playerNamePrefKey, value.text);
    }
}
