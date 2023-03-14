using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetServerBtnName : MonoBehaviour
{
    [SerializeField] Text textBtn;

    public void SetBtnName(string name)
    {
        textBtn.text = name;
    }
}
