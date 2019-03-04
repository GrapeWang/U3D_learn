using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isFly = false;
    private bool isReady = false;
    private Transform startpoint;
    private Transform circlepoint;
    private Vector3 tarPos;
    public float speed = 15;
    
    // Start is called before the first frame update
    void Start()
    {
        startpoint = GameObject.Find("StartPoint").transform;
        circlepoint = GameObject.Find("Circle").transform;
        tarPos = circlepoint.position;
        tarPos.y -= 1.55f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly == false)
        {
            if (isReady == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startpoint.position, 5f * Time.deltaTime);
                if (Vector3.Distance(transform.position, startpoint.position) <= 0.05f)
                {
                    isReady = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, tarPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, tarPos) <= 0.05f)
            {
                transform.position = tarPos;
                transform.parent = circlepoint;
                isFly = false;
            }
        }
    }

    public void FlyPin()
    {
        isFly = true;
        isReady = true;
    }
}
