using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using UnityEngine.Networking;
public class GetServerData : MonoBehaviour
{
    
    public Action<List<string>> GetServerNameAction;

    [Serializable]
    public class DPServer
    {
        public DPServerName[] rows;
    }

    [Serializable]
    public class DPServerName
    {
        public string serverId;
        public string serverName;
    }

    const string apiAddress = "https://api.neople.co.kr/df/servers?apikey=";
    const string apiKey = "Lwmq90k2FCVFchWTRJ4mKQBwh3ZFCyeP";
    void Start()
    {
        StartCoroutine(GetServerName());
    }

    IEnumerator GetServerName()
    {
        string api = string.Format("{0}{1}", apiAddress, apiKey);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(api))
        {
            yield return webRequest.SendWebRequest();
            if(webRequest.error == null)
            {
                // 데이터 가져와서 List에 정보 대입
                DPServer serverValue = JsonUtility.FromJson<DPServer>(webRequest.downloadHandler.text);
                List<string> serverNameList = new List<string>();
                for(int i = 0; i<serverValue.rows.Length; i++)
                {
                    serverNameList.Add(serverValue.rows[i].serverName);
                }
                GetServerNameAction?.Invoke(serverNameList);
            }
            else
            {
                Debug.Log(webRequest.error);
            }
        }
    }


}
