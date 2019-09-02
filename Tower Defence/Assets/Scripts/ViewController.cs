using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{

    private float keyspeed = 100;
    private float mousespeed = 2000;
    //private float sensitivity = 10;
    //private float minFov = 15;
    //private float maxFov = 100;
    private RaycastHit hit;
    private Vector3 Scenter = new Vector3(Screen.width / 2, Screen.height / 2, 0); //center in screen
    private Vector3 Wcenter; //center in world

    // Update is called once per frame
    void Update()
    { 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float leftspeed = 100;
        float rightspeed = 100;
        float upspeed = 100;
        float downspeed = 100;
        // center position
        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Scenter), out hit, 1000f,LayerMask.GetMask("Plane")))
        {
            Wcenter = hit.point;
        }
        //Debug.Log(Wcenter);

        // keyboard move
        if (Wcenter.x < -50f)
        {
            h = Mathf.Clamp(h, 0, 1);
            leftspeed = 0;
        }
        if (Wcenter.x> 70f)
        {
            h = Mathf.Clamp(h, -1, 0);
            rightspeed = 0;
        }

        if (Wcenter.z < -40f)
        {
            v = Mathf.Clamp(v, 0, 1);
            downspeed = 0;
        }
        if (Wcenter.z > 60f)
        {
            v = Mathf.Clamp(v, -1, 0);
            upspeed = 0;
        }
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * keyspeed, Space.World);

        // mouse move
        Vector3 v1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (v1.x < 0.005f)
        {
            transform.Translate(Vector3.left * leftspeed * Time.deltaTime, Space.World);
        }
        if (v1.x > 1 - 0.005f)
        {
            transform.Translate(Vector3.right * rightspeed * Time.deltaTime, Space.World);
        }
        if (v1.y < 0.005f)
        {
            transform.Translate(Vector3.back * downspeed * Time.deltaTime, Space.World);
        }
        if (v1.y > 1 - 0.005f)
        {
            transform.Translate(Vector3.forward * upspeed * Time.deltaTime, Space.World);
        }

        // distance zoom
        Vector3 v2 = Camera.main.WorldToScreenPoint(Wcenter);
        if (v2.z > 90f)
        {
            scroll = Mathf.Clamp(scroll, 0, 1);
        }
        if (v2.z < 30f)
        {
            scroll = Mathf.Clamp(scroll, -1, 0);
        }
        transform.Translate(new Vector3(0, 0, scroll) * Time.deltaTime * mousespeed);

        // fov zoom
        //float fov = Camera.main.fieldOfView;
        //fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        //fov = Mathf.Clamp(fov, minFov, maxFov);
        //Camera.main.fieldOfView = fov;

    }
}
