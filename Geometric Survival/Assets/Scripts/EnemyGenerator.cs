using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab_circle;
    public GameObject EnemyPrefab_square;
    public GameObject EnemyPrefab_triangle;
    private GameObject[] GeneratedEnemy = new GameObject[3];

    private float generationRate = 5f;
    private float rateDiscount = 0.95f;
    private Vector3 generatePosition;

    public GameObject[] SpawnEffect = new GameObject[3];
    private GameObject effect;

    private int index;

    public Text ScoreText;

    public static float Score = 0;
    private float totalScore = 0;

    public AudioClip gameoverClip;

    public static EnemyGenerator instance;
//    public GameObject Hero;
    // Start is called before the first frame update
    void Awake()
    {
 //       instance = this;
    }

    void Start()
    {
        DataManager.CurrentScene = SceneManager.GetActiveScene().buildIndex;
        DataManager.GameScore = 0;
        Score = 0;

        GeneratedEnemy[0] = EnemyPrefab_circle;
        GeneratedEnemy[1] = EnemyPrefab_square;
        GeneratedEnemy[2] = EnemyPrefab_triangle;

        generatePosition = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-5f, 3.5f), 0);
        StartCoroutine(enemyGnerate());
        StartCoroutine(CheckGameOver());
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.isPause)
        {
            return;
        }
        if (DataManager.heroHp>0)
        {
            totalScore = Time.timeSinceLevelLoad + Score;
            ScoreText.text = totalScore.ToString("0.0");
        }

    }
    

    IEnumerator enemyGnerate()
    {
        while (true)
        {
          // if (PauseManager.isPause==false)
          //  {
                index = Random.Range(0, 3);
                effect = GameObject.Instantiate(SpawnEffect[index], generatePosition, Quaternion.identity);
                Destroy(effect, 1f);
                yield return new WaitForSeconds(1f);
                GameObject.Instantiate(GeneratedEnemy[index], generatePosition, Quaternion.identity);
                generatePosition = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-5f, 3.5f), 0);
                yield return new WaitForSeconds(generationRate);
                generationRate = Mathf.Clamp(generationRate * rateDiscount, 0.1f, 5f);
          //  }
            
        }
            
        }

    

    IEnumerator CheckGameOver()
    {
        while (true)
        {
        //   if (PauseManager.isPause==false)
        //    {
                if (DataManager.heroHp <= 0)
                {
                    break;
                }
                yield return new WaitForSeconds(1f);
        //    }
        }
        DataManager.GameScore = totalScore;
        yield return new WaitForSeconds(1f);
        AudioManager.instance.playFX(gameoverClip);
        Invoke("GameoverScene", 2f);
    }

    //public void GameOver()
    //{
    //    DataManager.GameScore = totalScore;
    //    AudioManager.instance.playFX(gameoverClip);
    //    Invoke("GameoverScene", 2f);
    //}

    void GameoverScene()
    {
        SceneManager.LoadScene("gameover");
    }

}
