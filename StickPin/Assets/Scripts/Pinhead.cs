using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinhead : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pinhead")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }
}
