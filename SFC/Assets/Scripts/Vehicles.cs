using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private float speed = 10;
    void Start()
    {
        transform.forward = target.position-transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void SetTarget(Transform vehicleTarget)
    {
        target = vehicleTarget;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        if (transform.position == target.position)
        {

            ReachDestination();
        }
    }

    void ReachDestination()
    {
        Destroy(this.gameObject);
    }
}
