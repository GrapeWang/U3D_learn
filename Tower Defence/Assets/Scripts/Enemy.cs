using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public float hp = 150;
    private float maxHP;
    public GameObject explosionEffectPrefab;
    public Slider slider;
    private Transform[] anchorTrans;
    private int Index = 0;
    private GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        anchorTrans = Waypoints.anchorTrans;
        maxHP = hp;
 //       slider = gameObject.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //if (Index>anchorTrans.Length-1)
        //{
        //    return;
        //}
        //transform.Translate((anchorTrans[Index].position-transform.position).normalized*Time.deltaTime*speed);
        //if (Vector3.Distance(anchorTrans[Index].position,transform.position)<0.1f)
        //{
        //    //transform.position = anchorTrans[Index].position;
        //    //transform.position = new Vector3(0,0,0);
        //    Index++;
        //}
        transform.position = Vector3.MoveTowards(transform.position, anchorTrans[Index].position, Time.deltaTime * speed);
        if (transform.position == anchorTrans[Index].position)
        {
            if (Index == anchorTrans.Length-1)
            {
                ReachDestination();
                return;
            }
            Index++;
        }
        //Index++;
    }

    void ReachDestination()
    {
        Destroy(this.gameObject);
        DataManager.life--;
        if (DataManager.life>=0)
        {
            GameManager.instance.Life.text = "♥ " + DataManager.life;
        }
        
        if (DataManager.life <= 0)
        {
            // lose
            GameManager.instance.Fail();
        }
        //EnemyCreater.RemainEnemy--;
    }

    void OnDestroy()
    {
        EnemyCreater.RemainEnemy--;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        slider.value = hp / maxHP;
        if (hp<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect,1.5f);
    }
}
