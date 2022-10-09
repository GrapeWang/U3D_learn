using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleGenerator : MonoBehaviour
{
    public Transform[] BornPoint;
    public Transform[] TargetPoint;
    public Slider GenerationRate;
    private Coroutine co;
    private GameObject go;
    private float BornRate = 1.5f;
    public GameObject[] vehicles;

    private int BornIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        BornRate = 0.5f/(0.05f+GenerationRate.value);
    }
    public void StartGeneration()
    {
        co = StartCoroutine(VehicleGenerate());
    }

    public void StopGeneration()
    {
        StopCoroutine(co);
    }

    IEnumerator VehicleGenerate()
    {
        while (true)
        {
            BornIndex = Random.Range(0, 8);
            go = GameObject.Instantiate(vehicles[Random.Range(0,8)], BornPoint[BornIndex].position, Quaternion.identity);
            go.GetComponent<Vehicles>().SetTarget(TargetPoint[BornIndex]);
            yield return new WaitForSeconds(BornRate);
        }
    }
}
