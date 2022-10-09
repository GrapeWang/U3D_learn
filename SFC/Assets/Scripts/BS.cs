using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VolumetricLines;

public class BS : MonoBehaviour
{
    public List<GameObject> inVehicles = new List<GameObject>();
    public GameObject ChainPrefab;
    private VolumetricLineBehavior line;
    public float LineWidth;
    public float LineFactor;
    public Color LineColor;

    public Transform Detection;
    public Transform Forwarding;
    public Transform Inden;
    public Transform Fusion;
    public Transform Decision;

    private GameObject chainDF;
    private GameObject chainFI;
    private GameObject chainDI;
    private GameObject chainIFu;
    private GameObject chainFuDc;

    private VolumetricLineBehavior DF_line;
    private VolumetricLineBehavior FI_line;
    private VolumetricLineBehavior DI_line;
    private VolumetricLineBehavior IFu_line;
    private VolumetricLineBehavior FuDc_line;

    public Transform AerialPos1;
    public Transform AerialPos2;
    public Transform BsPos1;
    public Transform BsPos2;
    public Transform BsPos3;
    public float speed;

    public Slider ComResource;

    private bool inMigrationUp = false;

    private bool inMigrationDown = false;
    // Start is called before the first frame update
    void Start()
    {
        Forwarding.gameObject.SetActive(false);
        chainDF = CommunicateLine(Detection.position, Forwarding.position);
        DF_line = chainDF.GetComponent<VolumetricLineBehavior>();
        chainDF.SetActive(false);
        chainDI = CommunicateLine(Detection.position, Inden.position);
        DI_line = chainDI.GetComponent<VolumetricLineBehavior>();
        chainFI = CommunicateLine(Forwarding.position, Inden.position);
        FI_line = chainFI.GetComponent<VolumetricLineBehavior>();
        chainFI.SetActive(false);
        chainIFu = CommunicateLine(Inden.position, Fusion.position);
        IFu_line = chainIFu.GetComponent<VolumetricLineBehavior>();
        chainFuDc = CommunicateLine(Fusion.position, Decision.position);
        FuDc_line = chainFuDc.GetComponent<VolumetricLineBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        ComResource.value = 1 - Mathf.Clamp01((float)inVehicles.Count / 10f);

        if (ComResource.value<=0.2)
        {
            inMigrationUp = true;
            inMigrationDown = false;

        }

        if (ComResource.value>=0.8)
        {
            inMigrationDown = true;
            inMigrationUp = false;
        }

        if (inMigrationUp)
        {
            MoveUP();
            Forwarding.gameObject.SetActive(true);
            chainDF.SetActive(true);
            DF_line.EndPos = Forwarding.position;
            chainFI.SetActive(true);
            FI_line.EndPos = Inden.position;
            chainDI.SetActive(false);
            IFu_line.StartPos = Inden.position;
            IFu_line.EndPos = Fusion.position;
            FuDc_line.StartPos = Fusion.position;
            FuDc_line.EndPos = Decision.position;
        }

        if (inMigrationDown)
        {
            MoveDown();
            Forwarding.gameObject.SetActive(false);
            chainDF.SetActive(false);
            chainFI.SetActive(false);
            chainDI.SetActive(true);
            DI_line.EndPos = Inden.position;
            IFu_line.StartPos = Inden.position;
            IFu_line.EndPos = Fusion.position;
            FuDc_line.StartPos = Fusion.position;
            FuDc_line.EndPos = Decision.position;
        }
        
    }

    GameObject CommunicateLine(Vector3 startPos, Vector3 endPos)
    {
        GameObject go = GameObject.Instantiate(ChainPrefab);
        line = go.GetComponent<VolumetricLineBehavior>();
        line.StartPos = startPos;
        line.EndPos = endPos;
        line.LineWidth = LineWidth;
        line.gameObject.transform.parent = transform;
        line.LightSaberFactor = LineFactor;
        line.LineColor = LineColor;
        return go;
    }

    void MoveUP()
    {

        Inden.position = Vector3.MoveTowards(Inden.position, AerialPos1.position, Time.deltaTime * speed*3);
        Fusion.position = Vector3.MoveTowards(Fusion.position, AerialPos2.position, Time.deltaTime * speed*3);
        Decision.position = Vector3.MoveTowards(Decision.position, BsPos2.position, Time.deltaTime * speed);
        //if (Inden.position==AerialPos1.position)
        //{
        //    IndenReach();
        //}
        //if (Fusion.position == AerialPos2.position)
        //{
        //    FusionReach();
        //}
        //if (Decision.position == BsPos1.position)
        //{
        //    DecisionReach();
        //}
    }

    void MoveDown()
    {
        Inden.position = Vector3.MoveTowards(Inden.position, BsPos1.position, Time.deltaTime * speed * 3);
        Fusion.position = Vector3.MoveTowards(Fusion.position, BsPos2.position, Time.deltaTime * speed * 3);
        Decision.position = Vector3.MoveTowards(Decision.position, BsPos3.position, Time.deltaTime * speed);
    }

    //void IndenReach()
    //{
    //}

    //void FusionReach()
    //{
    //}

    //void DecisionReach()
    //{
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="vehicle")
        {
            inVehicles.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag=="vehicle")
        {
            inVehicles.Remove(col.gameObject);
        }
    }
}
