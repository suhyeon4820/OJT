using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginUI : MonoBehaviour
{

    [Header("LoginUI")]
    [SerializeField] GameObject loginUI;
    [SerializeField] GameObject serverUI;
    [SerializeField] InputField inputField;
    [SerializeField] Text textWarning;
    [SerializeField] Button btnLogin;

    [Header("ServerUI")]
    [SerializeField] GetServerData serverData;
    [SerializeField] Button btnPlay;
    [SerializeField] GameObject serverBtnObj;
    [SerializeField] Transform parentTransform;
    [SerializeField] Text textServerName;
    string inputID;
    // Start is called before the first frame update
    void Start()
    {
        SetListener();
        btnLogin.interactable = false;
        btnPlay.interactable = false;
        serverData.GetServerNameAction += CreateServerBtn;
    }

    void SetListener()
    {
        // 인풋필드
        inputField.characterLimit = 8;
        inputField.onValueChanged.AddListener((s) => CheckInputfieldText(s));
        // 텍스트
        textWarning.text = "4자리 이상의 id를 입력하세요";
        textServerName.text = "";
        // 버튼
        btnLogin.onClick.AddListener(() => OnClickLoginBtn());

        btnPlay.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
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
    }

    void CreateServerBtn(List<string> serverNameList)
    {
        for (int i = 0; i < serverNameList.Count; i++)
        {
            string serverName = serverNameList[i];
            GameObject serverBtn = Instantiate(serverBtnObj);
            serverBtn.transform.SetParent(parentTransform);
            SetServerBtnName setServerName = serverBtn.GetComponent<SetServerBtnName>();
            setServerName.SetBtnName(serverName);

            serverBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                btnPlay.interactable = true;
                textServerName.text = string.Format("{0} 서버를 선택했습니다.", serverName);
            });
        }
    }
}
