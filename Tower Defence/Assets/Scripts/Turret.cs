using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<GameObject> inEnemys= new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        inEnemys.Add(col.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        inEnemys.Remove(col.gameObject);
    }

    public bool useLaser = false;
    public float attackRate = 1;
    public float damageRate = 80;
    private float timer;
    public Transform firePosition;
    public GameObject bulletPrefab;
    public GameObject head;
    public LineRenderer laserRenderer;
    public GameObject laserEffect;
    private GameObject bullet;
    private Vector3 headTarget;
    private Vector3 effectTarget;

    void Start()
    {
        timer = attackRate;
    }

    void Update()
    {
        LookTarget();
        if (useLaser == false)
        {
            if (inEnemys.Count > 0)
            {
                timer += Time.deltaTime;
                if (timer > attackRate)
                {
                    timer = 0;
                    Attack();
                }
            }
        }
        else if (inEnemys.Count > 0)
        {
            if (inEnemys[0] == null)
            {
                RemoveList();
            }
            if (inEnemys.Count > 0 && inEnemys[0] != null)
            {
                laserRenderer.enabled = true;
                laserRenderer.SetPositions(new Vector3[] { firePosition.position, inEnemys[0].transform.position });
                effectTarget = this.gameObject.transform.position;
                effectTarget.y = inEnemys[0].transform.position.y;
                laserEffect.SetActive(true);
                laserEffect.transform.position = inEnemys[0].transform.position;
                laserEffect.transform.LookAt(effectTarget);
                inEnemys[0].GetComponent<Enemy>().TakeDamage(damageRate*Time.deltaTime);
            }
            else
            {
                laserRenderer.enabled = false;
                laserEffect.SetActive(false);
            }
        }
        else
        {
            laserRenderer.enabled = false;
            laserEffect.SetActive(false);
        }


    }

    void Attack()
    {
        if (inEnemys[0] == null)
        {
            RemoveList();
        }
        if (inEnemys.Count>0&&inEnemys[0]!=null)
        {
            bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            // Debug.Log(inEnemys[0].transform);
            bullet.GetComponent<Bullet>().SetTarget(inEnemys[0].transform);
        }
        else
        {
            timer = attackRate;
        }
    }

    void RemoveList()
    {
        for (int i = 0; i < inEnemys.Count; i++)
        {
            if (inEnemys[i] == null)
            {
                inEnemys.Remove(inEnemys[i]);
            }
        }
    }

    void LookTarget()
    {
        if (inEnemys.Count>0&&inEnemys[0]!=null)
        {
            headTarget = inEnemys[0].transform.position;
            headTarget.y = head.transform.position.y;
            head.transform.LookAt(headTarget);
        }
    }
}
