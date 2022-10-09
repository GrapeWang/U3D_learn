using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VolumetricLines;

public class PacketsGenerator : MonoBehaviour
{
    public Packets packets;
    public GameObject CommunicationPreFab;
    public Transform start;
    private Coroutine co;
    private GameObject go;
    private VolumetricLineBehavior line;
    public float LineWidth;
    public float LightSaberFactor;
    public Color LineColor;
    private float drawtime = 2;
    private float timer;

    // Start is called before the first frame update
    void OnEnable()
    {
 //       StartGeneration();
    }

    void Start()
    {
        Manager.instance.ShowCom += this.StartGeneration;
        Manager.instance.StopCom += this.StopGeneration;
        timer = 0;
    }

    // Update is called once per frame

    void Update()
    {
        if (line!=null)
        {
            line.EndPos = Vector3.MoveTowards(line.EndPos, packets.packetTarget.position, Time.deltaTime * Vector3.Distance(start.position,packets.packetTarget.position)/drawtime);
            if (line.EndPos == packets.packetTarget.position)
            {
                timer += Time.deltaTime;
                if (timer>5)
                {
                    ResetPos();
                    timer = 0;
                }
            }
        }

    }

    public void StartGeneration()
    {
        co = StartCoroutine(PacketGenerate());
        CommunicateLine();
    }

    public void StopGeneration()
    {
        StopCoroutine(co);
        Destroy(line.gameObject);
    }

    IEnumerator PacketGenerate()
    {
        while (true)
        {
           go = GameObject.Instantiate(packets.packetPrefab, start.position, Quaternion.identity);
           go.GetComponent<PacketsMove>().getTarget(packets.packetTarget);
           go.transform.parent = transform;
            yield return new WaitForSeconds(packets.generationRate);
        }
    }

    void CommunicateLine()
    {
        line = GameObject.Instantiate(CommunicationPreFab).GetComponent<VolumetricLineBehavior>();
        line.StartPos = start.position;
        line.EndPos = start.position;
        line.LineWidth = LineWidth;
        line.gameObject.transform.parent = transform;
        line.LightSaberFactor = LightSaberFactor;
        line.LineColor = LineColor;
    }

    void ResetPos()
    {
        line.EndPos = start.position;
    }
}
