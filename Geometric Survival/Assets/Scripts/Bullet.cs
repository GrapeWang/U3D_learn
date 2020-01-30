using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Transform targetPosition;
    private Rigidbody2D rd;
    private Vector3 dir;
    private int speed = 8;

    private int StrongDamage = 40;
    private int WeakDamage = 10;
    private int Damage = 20;
    private int BulletType;

    public GameObject ExplosionEffect;
    private GameObject effect;

    public AudioClip[] AudioExplosion = new AudioClip[4];
 //   private AudioSource audiosource;


    // Start is called before the first frame update
    void Start()
    {
 //       transform.up = targetPosition.position - transform.position;
 //       dir = (targetPosition.position - transform.position).normalized;
        dir = transform.up;
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletMove();
    }

    void BulletMove()
    {
 //       transform.Translate(Vector3.up * Time.deltaTime * speed,Space.Self);
        rd.MovePosition(transform.position+dir*Time.deltaTime*speed);
 //       rd.velocity = dir * speed;
    }

    public void SetTarget(Transform bulletTarget)
    {
        targetPosition = bulletTarget;
    }

    public void GetBulletType(int type)
    {
        BulletType = type;
    }

    void OnCollisionEnter2D(Collision2D col2d)
    {
        if (col2d.collider.tag=="Enemy_circle")
        {
            switch (BulletType)
            {
                case 0:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(Damage);
                    AudioManager.instance.playFX(AudioExplosion[0]);
                    break;
                case 1:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(WeakDamage);
                    AudioManager.instance.playFX(AudioExplosion[1]);
                    break;
                case 2:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(StrongDamage);
                    AudioManager.instance.playFX(AudioExplosion[2]);
                    break;
            }

            Die();
        }

        if (col2d.collider.tag == "Enemy_square")
        {
            switch (BulletType)
            {
                case 0:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(StrongDamage);
                    AudioManager.instance.playFX(AudioExplosion[2]);
                    break;
                case 1:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(Damage);
                    AudioManager.instance.playFX(AudioExplosion[0]);
                    break;
                case 2:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(WeakDamage);
                    AudioManager.instance.playFX(AudioExplosion[1]);
                    break;
            }

            Die();
        }

        if (col2d.collider.tag == "Enemy_triangle")
        {
            switch (BulletType)
            {
                case 0:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(WeakDamage);
                    AudioManager.instance.playFX(AudioExplosion[1]);
                    break;
                case 1:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(StrongDamage);
                    AudioManager.instance.playFX(AudioExplosion[2]);
                    break;
                case 2:
                    col2d.collider.GetComponent<EnemyMove>().TakeDamage(Damage);
                    AudioManager.instance.playFX(AudioExplosion[0]);
                    break;
            }

            Die();
        }

        if (col2d.collider.tag == "Border")
        {
            Die();
            AudioManager.instance.playFXonshot(AudioExplosion[3],0.3f);
        }

        if (col2d.collider.tag == "Bonus_circle"|| col2d.collider.tag == "Bonus_square"|| col2d.collider.tag == "Bonus_triangle")
        {
            col2d.collider.GetComponent<Bonus>().TakeDamage(WeakDamage);
            Die();
            AudioManager.instance.playFX(AudioExplosion[1]);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        effect = GameObject.Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Destroy(effect,1f);
    }
}
