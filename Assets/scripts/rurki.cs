using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rurki : MonoBehaviour
{
    public Rigidbody rurka;
    public flappy flappy;
    public int n = 0;
    public float speed = 15.0f;
    public static float speed2;
    public Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rurka = GetComponent<Rigidbody>();
        StartCoroutine("Speed");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenBounds.x*3)
        {
            Destroy(this.gameObject);
        }
        
    }

    IEnumerator Speed()
    {
        for (int i = 0; i <= n; i++)
        {
            rurka.velocity = new Vector3(-speed, 0, 0);
            yield return new WaitForSeconds(1.0f);
            n++;
            speed+=5;
        }

    }
    

}
