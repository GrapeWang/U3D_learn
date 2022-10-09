using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform aimTransform;
    private Transform holdPos_right;
    private Transform holdPos_left;
    private Transform gunEnd;
    //public Transform weaponPos;
    public SpriteRenderer WeaPonRenderer;
    private Vector3 mousePosition;
    private Vector3 aimDir;
    private float angle;
    private Animator PlayerAnim;

    public event EventHandler<onShootEventArgs> onShoot;
    public class onShootEventArgs : EventArgs
    {
        public Vector3 gunEndPosition;
        public Vector3 aimPosition;
    }

    private onShootEventArgs e = new onShootEventArgs();

    void Awake()
    {
        aimTransform = transform.Find("Aim");
        holdPos_right = transform.Find("HoldRight");
        holdPos_left = transform.Find("HoldLeft");
        gunEnd = transform.Find("Aim/gun/gunEndPosition");
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        aimDir = (mousePosition - transform.position).normalized;
        aimTransform.right = aimDir;
        angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        PlayerAnim.SetFloat("angle",angle);
        if ((-90<=angle&&angle<0) || (angle<=90&&angle>0))
        {
            aimTransform.position = holdPos_right.position;
            WeaPonRenderer.flipY = false;
        }
        else if ((-180 < angle && angle < -90) || (angle < 180 && angle > 90))
        {
            aimTransform.position = holdPos_left.position;
            WeaPonRenderer.flipY = true;
        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // PlayerAnim.SetTrigger("shoot");
            e.aimPosition = mousePosition;
            e.gunEndPosition = gunEnd.position;
            onShoot?.Invoke(this,e);
        }
    }
}
