using Assets.scripts;
using Assets.scripts.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getscore : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "Your Score: " + username.usrname + " " + CurrentScore.score;
    }

}
