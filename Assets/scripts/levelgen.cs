using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelgen : MonoBehaviour
{
    public GameObject Pipe;
    public int NumberofDanger = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        int i = 0;
        while(true)
        {
            Instantiate(Pipe, new Vector3(i * 2.0F, Random.Range(-0.63f, -9.45f), 14.29f), Quaternion.identity);
            yield return new WaitForSeconds(i > 31 ? 0.8f : 1f);
            i++;
            //int a = i > 5 ? 4 : -1;
            //// condition ? value if true : value if false
            //// nullable ?? value if null
            //GameObject aa = Pipe ?? new GameObject();
            //GameObject ab = Pipe == null ? new GameObject() : Pipe;
            //Transform t = Pipe?.transform;

        }
    }

}
