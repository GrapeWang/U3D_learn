using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        //GameObject.Instantiate(bullet,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hello Update");
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = GameObject.Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody r = b.GetComponent<Rigidbody>();
            r.velocity = transform.forward * speed;
        }
    }
}
