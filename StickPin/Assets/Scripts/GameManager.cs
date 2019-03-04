using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Transform startpoint;
    private Transform initialpoint;
    public GameObject pin;
    private Pin currentPin;
    private bool isGameover = false;
    private float score = 0;
    public Text scoreText;
    private Camera maincamera;

    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
        startpoint = GameObject.Find("StartPoint").transform;
        initialpoint = GameObject.Find("InitialPoint").transform;
        initialPin();
    }

    private void Update()
    {
        if (isGameover) return;
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            scoreText.text = score.ToString();
            currentPin.FlyPin();
            initialPin();
        }
    }

    void initialPin()
    {
        currentPin = GameObject.Instantiate(pin, initialpoint.position, pin.transform.rotation).GetComponent<Pin>();
    }

    public void GameOver()
    {
        if(isGameover) return;
        isGameover = true;
        GameObject.Find("Circle").GetComponent<Rotate>().enabled = false;
        StartCoroutine(GameoverAnim());
    }

    IEnumerator GameoverAnim()
    {
        while (true)
        {
            maincamera.backgroundColor = Color.Lerp(maincamera.backgroundColor, Color.red, 3 * Time.deltaTime);
            maincamera.orthographicSize = Mathf.Lerp(maincamera.orthographicSize, 4, 3 * Time.deltaTime);
            yield return 0;
            if (Mathf.Abs(maincamera.orthographicSize - 4) <= 0.01f)
            {
                break;
            }
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
