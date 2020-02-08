using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Vector3 targetPosition;
    private int counter = 0;
    private float MoveSpeed = 1f;
    private float changeRatemin = 2f;
    private float changeRatemax = 5f;
    private float changeRate;

    private float hp = 100;

    public GameObject ExplosionEffect;
    private GameObject effect;

    public AudioClip explosionClip;

    public GameObject Bonus;

    private int EnemyDestroyScore = 10;
    // Start is called before the first frame update
    void Start()
    {
        changeRate = Random.Range(changeRatemin, changeRatemax);
        MoveSpeed = MoveSpeed * Time.deltaTime;
        targetPosition = new Vector3(Random.Range(-50f,50f),Random.Range(-50f,50f),0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.isPause)
        {
            return;
        }
        Move();
    }

    void Move()
    {
        if (counter < changeRate / Time.deltaTime && Vector3.Distance(gameObject.transform.position, targetPosition) > 0.1f)
        {
            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPosition, MoveSpeed);
            counter++;
        }
        else
        {
            changeMove();
        }
    }

    public void TakeDamage(float damage)
    {
        hp = hp - damage;
        if (hp<=0)
        {
            EnemyGenerator.Score += EnemyDestroyScore;

            AudioManager.instance.playEnemyFX(explosionClip);
            
            effect = GameObject.Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(effect,1.5f);
            GameObject.Instantiate(Bonus, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    void changeMove()
    {
        counter = 0;
        targetPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0);
        changeRate = Random.Range(changeRatemin, changeRatemax);
    }

    void backMove()
    {
        targetPosition = transform.position + transform.position - targetPosition;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Enemy_circle" || col.collider.tag == "Enemy_square" || col.collider.tag == "Enemy_triangle" || col.collider.tag == "Border")
        {
            Invoke("backMove",0.1f);
        }
    }
}
