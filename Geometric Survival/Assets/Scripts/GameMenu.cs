using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

    public void OnRetryGame()
    {
        SceneManager.LoadScene(DataManager.CurrentScene);
    }
}
