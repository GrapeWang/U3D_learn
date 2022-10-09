using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using VolumetricLines;

public class SFC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform RSUPosition;
    public Transform BSPosition;
    public Transform AerialPosition;
    public Transform UEPosition;
    public GameObject packetPrefab;
    private GameObject packet;
    public GameObject camSFC;
    private CinemachineVirtualCamera camSFCVirtual;
    public static bool isShowSFC;
    private float speed = 10;
    private Transform[] anchorTrans;
    private int Index;
    public Material DeteM;
    public Material ForwM;
    public Material FusionM;
    public Material DecM;
    public GameObject DeteEffect;
    public GameObject ForwEffect;
    public GameObject FusionEffect;
    public GameObject ChainPrefab;
    private VolumetricLineBehavior line;
    public float LineWidth;
    public float LineFactor;
    public Color LineColor;
    private GameObject Chain1;
    private GameObject Chain2;
    public GameObject DeteBorn;
    public GameObject ForwBorn;
    public GameObject FusBorn;
    public GameObject DecBorn;
    private bool isVehicleMove;
    private Vector3 VehicleInitialPos;

    void Start()
    {
        camSFCVirtual = camSFC.GetComponent<CinemachineVirtualCamera>();
        isShowSFC = false;
        anchorTrans = new Transform[]{BSPosition,AerialPosition,BSPosition,UEPosition};
        Chain1 = CommunicateLine(RSUPosition.position,BSPosition.position);
        Chain1.SetActive(false);
        Chain2 = CommunicateLine(BSPosition.position, AerialPosition.position);
        Chain2.SetActive(false);
        isVehicleMove = false;
        VehicleInitialPos = UEPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        VehicleMove();
    }

    public void OnShowSFC()
    {
        if (isShowSFC)
        {
            camSFCVirtual.Priority = 10;
            isShowSFC = false;
            isVehicleMove = false;
            GameObject.Destroy(packet);
            Chain1.SetActive(false);
            Chain2.SetActive(false);
            UEPosition.position = VehicleInitialPos;
            UEPosition.gameObject.SetActive(false);
        }
        else
        {
            camSFCVirtual.Priority = 100;
            isShowSFC = true;
            isVehicleMove = false;
            StartCoroutine(GeneratePacket(RSUPosition,DeteBorn, DeteM, 3));
            Chain1.SetActive(true);
            Chain2.SetActive(true);
            UEPosition.gameObject.SetActive(true);
            UEPosition.position = VehicleInitialPos;
        }
    }

    private IEnumerator GeneratePacket(Transform targeTransform,GameObject eff,Material mater,float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Destroy(GameObject.Instantiate(eff, targeTransform.position, Quaternion.identity),2f);
        yield return new WaitForSeconds(1);
        packet = GameObject.Instantiate(packetPrefab, targeTransform.position, Quaternion.identity);
        packet.GetComponent<MeshRenderer>().material = mater;
        camSFCVirtual.Follow = packet.transform;
        camSFCVirtual.LookAt = packet.transform;
    }

    void Move()
    {
        if (packet!=null)
        {
            packet.transform.position = Vector3.MoveTowards(packet.transform.position, anchorTrans[Index].position, Time.deltaTime * speed);
            if (packet.transform.position == anchorTrans[Index].position)
            {
                switch (Index)
                {
                    case 0:
                        ReachBS();
                        break;
                    case 1:
                        ReachAerial();
                        break;
                    case 2:
                        ReachBS2();
                        break;
                    case 3:
                        ReachUE();
                        Index = -1;
                        break;
                }
                Index++;
            }
        }
        
    }


    void ReachBS()
    {
        GameObject.Destroy(packet);
        GameObject.Destroy(GameObject.Instantiate(DeteEffect, BSPosition.position, Quaternion.identity),2);
        StartCoroutine(GeneratePacket(BSPosition,ForwBorn, ForwM, 2));
        speed = 20;

    }

    void ReachAerial()
    {
        GameObject.Destroy(packet);
        GameObject.Destroy(GameObject.Instantiate(ForwEffect, AerialPosition.position, Quaternion.identity), 2);
        StartCoroutine(GeneratePacket(AerialPosition, FusBorn,FusionM, 2));
    }

    void ReachBS2()
    {
        GameObject.Destroy(packet);
        GameObject.Destroy(GameObject.Instantiate(FusionEffect, BSPosition.position, Quaternion.identity), 2);
        StartCoroutine(GeneratePacket(BSPosition,DecBorn, DecM, 2));
        speed = 10;
    }

    void ReachUE()
    {
        GameObject.Destroy(packet);
        isVehicleMove = true;
    }

    GameObject CommunicateLine(Vector3 startPos,Vector3 endPos)
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

    void VehicleMove()
    {
        if (isVehicleMove)
        {
            UEPosition.Translate(-UEPosition.forward*Time.deltaTime*speed,Space.Self);
        }
    }
}
