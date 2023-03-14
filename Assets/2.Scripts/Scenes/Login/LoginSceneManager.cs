using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginSceneManager : MonoBehaviour
{
    [SerializeField] GameObject loginUI;
    [SerializeField] GameObject serverUI;
    [SerializeField] InputField inputField;
    [SerializeField] Text textWarning;
    [SerializeField] Button btnLogin;
    string inputID;
    // Start is called before the first frame update
    void Start()
    {
        SetListener();
        btnLogin.interactable = false;
    }

    void SetListener()
    {
        // 인풋필드
        inputField.characterLimit = 8;
        inputField.onValueChanged.AddListener((s) => CheckInputfieldText(s));
        // 텍스트
        textWarning.text = "4자리 이상의 id를 입력하세요";
        // 버튼
        btnLogin.onClick.AddListener(() => OnClickLoginBtn());
    }

    void CheckInputfieldText(string inputText)
    {
        if (inputText.Length >= 4)
        {
            btnLogin.interactable = true;
            textWarning.text = "로그인이 가능합니다";
        }
        inputID = inputText;
    }

    void OnClickLoginBtn()
    {
        loginUI.gameObject.SetActive(false);
        serverUI.gameObject.SetActive(true);
        //PlayerPrefs.SetString("ID", inputID.ToString());
        //StartCoroutine(sceneManager.LoadScene(this.gameObject.GetComponent<MainUI>()));
    }

}
