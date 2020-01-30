using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float speed=1;
    public float force = 5;
    public GameObject AimPoint;
    public Transform FirePoint;
    public GameObject[] FireMode = new GameObject[3];
    public GameObject[] Bullet = new GameObject[3];
//    public GameObject head;
    private float h;
    private float v;
    private Rigidbody2D rd;
    private int fireindex = 0;
    private GameObject bullet;

    public AudioClip Switch;
    public AudioClip[] Fire = new AudioClip[3];
    private AudioSource audiosource;

    private GameObject effect;
    public Transform EffectPoint;
    public GameObject FireEffect;

    private int hp = 200;
    private int EnemyColDamage = 10;

    public AudioClip explosionClip;
    public AudioClip ColClip;
    public GameObject ExplosionEffect;
    public GameObject ColEffect;
    private GameObject coleffect;

    private int[] Bulnum = new int[3]{10,10,10};
    private int BulnumMax = 20;
    private int BonusBulnum = 10;
    public AudioClip BulletEmptyClip;


 //   public LineRenderer fireline;
 //   private Vector3 headTarget;
 // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LookTarget();
        ForceMove();
        SwitchMode();
        FireBullet();
    }

    void ForceMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h, v, 0) * force);
        //rd.MovePosition(transform.position+new Vector3(h,v,0) * speed * Time.deltaTime);
    }

    void LookTarget()
    {
       transform.up = AimPoint.transform.position-transform.position;
    //   fireline.enabled = true;
    //   fireline.SetPositions(new Vector3[]{EffectPoint.position,AimPoint.transform.position});
    }

    void SwitchMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            fireindex = (fireindex + 1) % 3;
            FireMode[fireindex].SetActive(true);
            FireMode[(fireindex + 1) % 3].SetActive(false);
            FireMode[(fireindex + 2) % 3].SetActive(false);
            audiosource.clip = Switch;
            audiosource.Play();
        }
    }

    void FireBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Bulnum[fireindex]>0)
            {
                bullet = GameObject.Instantiate(Bullet[fireindex], FirePoint.position, Quaternion.identity);
                bullet.transform.up = transform.up;
                bullet.GetComponent<Bullet>().SetTarget(AimPoint.transform);
                bullet.GetComponent<Bullet>().GetBulletType(fireindex);
                audiosource.clip = Fire[fireindex];
                if (fireindex == 0)
                {
                    audiosource.PlayOneShot(audiosource.clip, 0.6f);
                }
                else
                {
                    audiosource.Play();
                }
                effect = GameObject.Instantiate(FireEffect, EffectPoint.position, Quaternion.Euler(-90, 0, 0));
                Destroy(effect, 0.5f);
                Bulnum[fireindex]--;
                Bulnum[fireindex] = Mathf.Clamp(Bulnum[fireindex], 0, BulnumMax);
            }
            else
            {
                audiosource.clip = BulletEmptyClip;
                audiosource.Play();
            }
            

            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag=="Enemy_circle"|| col.collider.tag == "Enemy_square"|| col.collider.tag == "Enemy_triangle")
        {
            hp = hp - EnemyColDamage;
            AudioManager.instance.playEnemyFX(ColClip);
            coleffect=GameObject.Instantiate(ColEffect, col.GetContact(0).point, Quaternion.identity);
            Destroy(coleffect,1f);
            if (hp<=0)
            {
                Die();
            }
        }

        if (col.collider.tag == "Bonus_circle")
        {
            Bulnum[0] += BonusBulnum;
            Bulnum[0] = Mathf.Clamp(Bulnum[0], 0, BulnumMax);
        }

        if (col.collider.tag == "Bonus_square")
        {
            Bulnum[1] += BonusBulnum;
            Bulnum[1] = Mathf.Clamp(Bulnum[1], 0, BulnumMax);
        }

        if (col.collider.tag == "Bonus_triangle")
        {
            Bulnum[2] += BonusBulnum;
            Bulnum[2] = Mathf.Clamp(Bulnum[2], 0, BulnumMax);
        }
    }

    void Die()
    {
        AudioManager.instance.playEnemyFX(explosionClip);
        Destroy(this.gameObject);
        effect = GameObject.Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
    }
}
