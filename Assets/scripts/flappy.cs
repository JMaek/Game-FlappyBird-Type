using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class flappy : MonoBehaviour
{
    public Vector3 jump;
    public Rigidbody birb;
    [Range(0, 20)]
    public float jumpForce = 8f;
    public float fallForce = 2.5f;
    public rurki rurki;
   
    // Start is called before the first frame update
    void Start()
    {
       
        birb = GetComponent<Rigidbody>();
        CurrentScore.score = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            birb.velocity = Vector3.up * jumpForce;
        }
        else
        {
            if (birb.velocity.y < 0)
            {
              birb.velocity += Vector3.up * Physics2D.gravity.y * (fallForce - 1) * Time.deltaTime;
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ded")
        {
            Time.timeScale = 0;
            transform.GetComponent<Renderer>().material.color = Color.red;
            SceneManager.LoadScene("RIP");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            CurrentScore.score += 1;
        }
    }

}
