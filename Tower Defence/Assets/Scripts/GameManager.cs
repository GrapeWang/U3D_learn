using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;
    public Text Message;
    public Text Life;
    public static GameManager instance;
    private EnemyCreater enemyCreater;

    void Awake()
    {
        instance = this;
        enemyCreater = this.GetComponent<EnemyCreater>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        Message.text = "Congratulations!";
    }

    public void Fail()
    {
        endUI.SetActive(true);
        Message.text = "GAME OVER";
        enemyCreater.Stop();
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
