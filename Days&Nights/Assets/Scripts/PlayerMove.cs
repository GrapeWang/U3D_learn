using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //   [SerializeField] private LayerMask dashLayerMask;
    private enum State
    {
        normal,rolling,
    }
    private const float MOVE_SPEED = 3;
    private const float DASH_AMOUNT = 3;
    private const float Roll_STARTSPEED = 15;
    private const float Roll_MIN = 3.22f;
    private Animator PlayerAnim;
    private Rigidbody2D rd;
    private float h;
    private float v;
    private Vector3 movDir;
    private Vector3 rollDir;
    private Vector3 DashPosition;
    private bool isDash;
    private float RollSpeed;
    private float rollspeedMultiplier = 3f;
    private bool isWeapon = true;

    private State state;
//    private RaycastHit2D raycastHit2D;

    void Awake()
    {
        PlayerAnim = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
        state = State.normal;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isWeapon = !isWeapon;
        }
        if (isWeapon)
        {
            PlayerAnim.SetBool("isWeapon",true);
        }
        else
        {
            PlayerAnim.SetBool("isWeapon",false);
        }
        switch (state)
        {
            case State.normal:
                h = Input.GetAxisRaw("Horizontal");
                v = Input.GetAxisRaw("Vertical");
                movDir = new Vector3(h, v, 0).normalized;
                PlayerAnim.SetInteger("Horizontal", (int) Input.GetAxisRaw("Horizontal"));
                PlayerAnim.SetInteger("Vertical", (int) Input.GetAxisRaw("Vertical"));

                if (Input.GetKeyDown(KeyCode.F))
                {
                    isDash = true;
                }

                if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        rollDir = movDir;
                        state = State.rolling;
                        RollSpeed = Roll_STARTSPEED;
                        PlayerAnim.SetTrigger("Roll");
                    }
                }
                
                break;
            case State.rolling:
                RollSpeed -= RollSpeed * rollspeedMultiplier * Time.deltaTime;
                if (RollSpeed < Roll_MIN)
                {
                    state = State.normal;
                }
                break;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.normal:
                rd.velocity = movDir * MOVE_SPEED;
                //rd.MovePosition(transform.position + new Vector3(h, v, 0).normalized * speed * Time.deltaTime);
                if (isDash)
                {
                    DashPosition = transform.position + movDir * DASH_AMOUNT;

                    //raycastHit2D = Physics2D.Raycast(transform.position, movDir, DASH_AMOUNT, dashLayerMask);
                    //if (raycastHit2D.collider !=  null)
                    //{
                    //    DashPosition = raycastHit2D.point;
                    //}
                    rd.MovePosition(DashPosition);
                    isDash = false;
                }
                break;
            case State.rolling:
                rd.velocity = rollDir * RollSpeed;
                break;
        }
    }
}
