using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadToMain()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
        Application.Quit();
        DataManager.instance.SaveNameScore();
    }
}
