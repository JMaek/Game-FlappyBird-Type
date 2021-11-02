using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Button button = transform.GetComponent<Button>();
        button.onClick.AddListener(Usermenu);
    }

    public void Usermenu()
    {
        SceneManager.LoadScene(sceneName);
    }

}
