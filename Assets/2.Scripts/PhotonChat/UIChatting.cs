using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIChatting : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text chatText;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] PhotonChatManager photonChatManager;
    private void Start()
    {
        SetListener();
        photonChatManager.ReturnChatInputAction += UpdateChattingWindow;
    }
    private void OnDisable()
    {
        photonChatManager.ReturnChatInputAction -= UpdateChattingWindow;
    }

    void SetListener()
    {
        inputField.onEndEdit.AddListener((input) => GetUserInput(input));
    }

    void GetUserInput(string userInput)
    {
        if(string.IsNullOrEmpty(userInput))
        {
            return;
        }
        else
        {
            Debug.Log(userInput);
            photonChatManager.SendInputMessage(userInput);
        }   
        inputField.text = "";
    }

    void UpdateChattingWindow(string userName, string inputMessage)
    {
        string message = string.Format("[{0}] : {1}\n", userName, inputMessage);
        chatText.text += message;
    }
}
