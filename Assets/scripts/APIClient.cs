
using Assets.scripts.DataTypes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.scripts
{
    public class APIClient
    {
        private static readonly string BASE_URL = "http://localhost:56230";

        public IEnumerator GetUsers(Action<IEnumerable<User>> callback)
        {
            using (UnityWebRequest uwr = UnityWebRequest.Get($"{BASE_URL}/api/users"))
            {
                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError)
                {
                    Debug.Log(uwr.error);
                }
                else
                {
                    var d1 = uwr.downloadHandler.text;
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(d1);
                    callback(users);
                }
            }
        }
        public IEnumerator GetScores(Action<IEnumerable<Score>> callback)
        {
            using (UnityWebRequest request = UnityWebRequest.Get($"{BASE_URL}/api/scores"))
            {
                yield return request.SendWebRequest();

                if (request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    var d = request.downloadHandler.text;
                    List<Score> scores = JsonConvert.DeserializeObject<List<Score>>(d).OrderByDescending(s => s.Points).Take(10).ToList();
                    callback(scores);
                }
            }
        }
    }
}
