using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Text text;
    public GameObject goodtext;
    public GameObject idiottext;
    public GameObject pertext;
    private int score = 0;
    public int force = 5;
    public int Jforce = 25;
    private Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent< Rigidbody >();
        text.text = "Point: 0";
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");
        rd.AddForce(new Vector3(h, 0, v) * force);
        if( Input.GetKeyDown("space"))
        {
            rd.AddForce(new Vector3(0, 1, 0) * Jforce);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            idiottext.SetActive(true);
            Invoke("shutidiot", 3.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gold")
        {
            Destroy(other.gameObject);
            score++;
            text.text = "Point: "+score.ToString();
            if (score == 8)
            {
                goodtext.SetActive(true);
            }

            if (score == 10)
            {
                goodtext.SetActive(false);
                pertext.SetActive(true);
            }
        }

    }

    private void shutidiot()
    {
        idiottext.SetActive(false);
    }
    
}
