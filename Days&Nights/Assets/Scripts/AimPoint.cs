using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    private float rotateSpeed = 120;

    private Vector3 target;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        transform.position = target;
    }
}
