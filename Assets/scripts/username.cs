using Assets.scripts.DataTypes;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class username : MonoBehaviour
{
    public InputField UserName;
    public static string usrname;
    public static int Userid;
    public GameObject[] YN;
    public Text message;
    public Button button;
    readonly string URL = "http://localhost:56230/api/users";
    // Start is called before the first frame update
    void Start()
    {
        YN = GameObject.FindGameObjectsWithTag("restart");
        button.onClick.AddListener(OnButtonPost);
        HideYN();
    }
   

    public void OnButtonPost()
    {
        StartCoroutine(PostUsername(UserName.text, Userid));
        message.text = "Sending...";
        if (usrname != UserName.text)
        {
            usrname = UserName.text;
        }
    }

    public void HideYN()
    {
        foreach (GameObject g in YN)
        {
            g.SetActive(false);
        }
    }

    public void ShowYN()
    {
        foreach (GameObject g in YN)
        {
            g.SetActive(true);
        }
    }
    
    IEnumerator PostUsername(string UserName, int UserId)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:56230/api/users"))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                message.text = "Sth went wrong";
            }
            else // Success
            {
                var d = request.downloadHandler.text;
                List<User> usersList = JsonConvert.DeserializeObject<List<User>>(d);
                User found = null;
                for (int i = 0; i < usersList.Count; i++)
                {
                    if (usersList[i].UserName == UserName)
                    {
                        found = usersList[i];
                        message.text = "User with this name exists. Do you want to continue?";
                        ShowYN();
                        break;
                    }
                }
                //if (usersList.Any(u => u.UserName == UserName))
                if (found == null)
                {
                    using (UnityWebRequest uwr = new UnityWebRequest(URL, "POST"))
                    {
                        var data = JsonUtility.ToJson(new UserForCreation() { UserName = UserName });
                        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(data);
                        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
                        uwr.downloadHandler = new DownloadHandlerBuffer();
                        uwr.SetRequestHeader("Content-Type", "application/json");

                        yield return uwr.SendWebRequest();

                        if (uwr.isNetworkError || uwr.isHttpError)
                        {
                            Debug.Log(uwr.error);
                            message.text = "Sth went wrong";
                        }
                        else
                        {
                            var d1 = uwr.downloadHandler.text;
                            found = JsonConvert.DeserializeObject<User>(d1);
                            message.text = "Added new user";
                            SceneManager.LoadScene("Flapppy");
                            Time.timeScale = 1;
                        }
                    }
                }
                Debug.Log(found.UserName);
                Debug.Log(found.UserId);
                if(Userid != found.UserId)
                {
                    Userid = found.UserId;
                }
            }
        }

    }
    

}
