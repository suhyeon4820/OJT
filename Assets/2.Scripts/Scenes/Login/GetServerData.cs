using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GetServerData : MonoBehaviour
{
    [SerializeField] Button btnPlay;
    [SerializeField] GameObject serverBtn;
    void Start()
    {
        SetListener();
    }

    void SetListener()
    {
        btnPlay.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
