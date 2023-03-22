using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIChatting : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] PhotonChatManager photonChatManager;
    private void Start()
    {
        SetListener();
    }

    void SetListener()
    {
        inputField.onEndEdit.AddListener((input) => GetUserInput(input));
    }

    void GetUserInput(string userInput)
    {
        Debug.Log(userInput);
        photonChatManager.SendMessage(userInput);
        inputField.text = "";
    }
}
