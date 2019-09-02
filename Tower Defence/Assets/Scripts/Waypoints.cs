using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] anchorTrans;

    void Awake()
    {
        anchorTrans = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < anchorTrans.Length; i++)
        {
            anchorTrans[i] = transform.GetChild(i);
        }
    }
}
