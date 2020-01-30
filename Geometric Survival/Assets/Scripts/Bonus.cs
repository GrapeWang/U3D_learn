using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private Vector3 targetPosition;
    private int counter = 0;
    private float MoveSpeed = 0.3f;
    private float changeRatemin = 2f;
    private float changeRatemax = 5f;
    private float changeRate;

    private float hp = 30;

    public GameObject ExplosionEffect;
    private GameObject effect;

    public AudioClip explosionClip;
    public AudioClip BonusClip;
    // Start is called before the first frame update
    void Start()
    {
        changeRate = Random.Range(changeRatemin, changeRatemax);
        MoveSpeed = MoveSpeed * Time.deltaTime;
        targetPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, 5f), 0);
    }

    // Update is called once per frame
    void Update()
    {
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
            counter = 0;
            targetPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, 5f), 0);
            changeRate = Random.Range(changeRatemin, changeRatemax);
        }
    }

    public void TakeDamage(float damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            AudioManager.instance.playEnemyFX(explosionClip);
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        effect = GameObject.Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Hero")
        {
            AudioManager.instance.playEnemyFX(BonusClip);
            Die();
        }
    }
}
