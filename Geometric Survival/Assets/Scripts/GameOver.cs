using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Score: " + DataManager.GameScore.ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
