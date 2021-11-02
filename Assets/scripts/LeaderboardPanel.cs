using Assets.scripts;
using Assets.scripts.DataTypes;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardPanel : MonoBehaviour
{
    public Transform container;
    public GameObject krecha;

    // Start is called before the first frame update
    void Start()
    {
        container = transform.Find("Panel");
        StartCoroutine(Leader());
    }

    IEnumerator Leader()
    {
        IEnumerable<User> users = null;
        yield return new APIClient().GetUsers(res => users = res);

        IEnumerable<Score> scores = null;
        yield return new APIClient().GetScores(res => scores = res);

        if (scores != null && users != null)
        {
            for (var i = 0; i < scores.Count(); i++)
            {
                var score = scores.ElementAt(i);
                GameObject kopiuj = Instantiate(krecha, container) as GameObject;
                krecha.transform.localPosition = new Vector3(0, 26 * i, 0);
                Krecha k = kopiuj.GetComponent<Krecha>();
                k.SetData(users.FirstOrDefault(u => u.UserId == score.UserId)?.UserName, score.Points.ToString(), i);
                k.Highlight(score.UserId == username.Userid);
            }
        }
    }

}


