using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    public float speed = 2;
    public float damage = 20;
    public float maxDis = 200;
    public GameObject explosinEffect;
    private GameObject effect;
    //public float force = 1000;

    public void SetTarget(Transform bulletTarget)
    {
        target = bulletTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
        //gameObject.GetComponent<Rigidbody>().AddForce((target.position - transform.position) * force);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        if (Vector3.Distance(transform.position, target.position) > maxDis)
        {
            Destroy(this.gameObject);
            return;
        }

        if (gameObject.tag == "Missile")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            effect = GameObject.Instantiate(explosinEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(effect,1);
        }
        
    }


}
