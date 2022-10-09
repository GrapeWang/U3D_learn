using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketsMove : MonoBehaviour
{
    public float speed = 10;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void getTarget(Transform packetTarget)
    {
        target = packetTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        if (transform.position == target.position)
        {
            
            ReachDestination();
            return;
        }
    }
    public void ReachDestination()
    {
        Destroy(this.gameObject);
    }
}
