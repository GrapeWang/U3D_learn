using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Manager instance;
    public GameObject environment;
    public GameObject networks;
    public GameObject topology;
    public static bool isTopologyOn;
    public static bool isOverlookOn;
    public GameObject camOver;
    private CinemachineVirtualCamera camOverVirtual;
    public CinemachineVirtualCamera camMig;
    public CinemachineVirtualCamera camMig2;
    public event Action ShowCom;
    public event Action StopCom;
    public static bool isShowCom;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isTopologyOn = false;
        isOverlookOn = false;
        isShowCom = false;
        topology.SetActive(false);
        networks.SetActive(true);
        environment.SetActive(true);
        camOverVirtual = camOver.GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            int temp = camMig2.Priority;
            camMig2.Priority = camMig.Priority;
            camMig.Priority = temp;
        }
        
    }

    public void onViewChange()
    {
        if (isTopologyOn)
        {
            topology.SetActive(false);
            networks.SetActive(true);
            environment.SetActive(true);
            isTopologyOn = false;
        }
        else
        {
            topology.SetActive(true);
            networks.SetActive(false);
            environment.SetActive(false);
            isTopologyOn = true;
        }
    }

    public void onOverlookChange()
    {
        if (isOverlookOn)
        {
            camOverVirtual.Priority = 10;
            isOverlookOn = false;
        }
        else
        {
            camOverVirtual.Priority = 100;
            isOverlookOn = true;
        }
    }

    public void onComChange()
    {
        if (isShowCom)
        {
            StopCom();
            isShowCom = false;
        }
        else
        {
            ShowCom();
            isShowCom = true;
        }
    }
}
