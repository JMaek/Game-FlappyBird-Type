using Assets.scripts;
using Assets.scripts.DataTypes;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScorePost : MonoBehaviour
{
    public Button submit;
    public Text mess;
    public int scor;
    public int Id;
    readonly string URL = "http://localhost:56230/api/scores";
    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(Submit);
        scor = CurrentScore.score;
        Id = username.Userid;
    }

    public void Submit()
    {
        StartCoroutine(PostScore(scor, Id));
    }
    IEnumerator PostScore(int yourSore, int UserId)
    {
        using (UnityWebRequest uwr = new UnityWebRequest(URL, "POST"))
        {
            var data = JsonUtility.ToJson(new ScoreForCreation() { Points = yourSore, UserId = UserId, GameId = 3 });
            byte[] jsonToSend = new UTF8Encoding().GetBytes(data);
            uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
                mess.text = "Sth went wrong";
            }
            else
            {
                mess.text = "Sent";
            }
        }
        Debug.Log(yourSore);
        Debug.Log(UserId);
    }
}
