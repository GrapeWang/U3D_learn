using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public AudioClip pauseClip;

    public static bool isPause = false;
    //private bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
 //       PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();
    }

    void ShowPauseUI()
    {
       AudioManager.instance.playFX(pauseClip);
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        isPause = true;
    }

    public void ExitPauseUI()
    {
        isPause = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void OnStartGame(string scene)
    {
        ExitPauseUI();
        SceneManager.LoadScene(scene);
    }

    public void OnRetryGame()
    {
        ExitPauseUI();
        SceneManager.LoadScene(DataManager.CurrentScene);
    }

    void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {

                ExitPauseUI();

            }
            else
            {
                ShowPauseUI();
            }
        }
    }
}
