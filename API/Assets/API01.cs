using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.SendMessage("Attack");
        Invoke("Attack",2);
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        print("Attack");
    }
}
