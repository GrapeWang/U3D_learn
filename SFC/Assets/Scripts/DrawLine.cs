using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Material LineMaterial;
    private MeshRenderer LineMesh;
    public Transform AerialNode;
    public Transform BS1;
    public Transform BS2;
    public Transform BS3;
    public Transform BS4;
    public Transform RSU1;
    public Transform RSU2;
    public Transform RSU3;
    public Transform RSU4;
    public Transform RSU5;
    public Transform RSU6;
    public Transform RSU7;
    public Transform RSU8;
    public Transform RSU9;
    public Transform RSU10;
    void Start()
    {
        DrawLS(BS1,BS2,10f);
        DrawLS(BS1, BS4, 10f);
        DrawLS(BS3, BS2, 10f);
        DrawLS(BS3, BS4, 10f);
        DrawLS(BS1, RSU1, 5f);
        DrawLS(BS1, RSU2, 5f);
        DrawLS(BS1, RSU3, 5f);
        DrawLS(BS2, RSU4, 5f);
        DrawLS(BS2, RSU5, 5f);
        DrawLS(BS3, RSU6, 5f);
        DrawLS(BS3, RSU7, 5f);
        DrawLS(BS3, RSU8, 5f);
        DrawLS(BS4, RSU9, 5f);
        DrawLS(BS4, RSU10, 5f);

        DrawLS(AerialNode, RSU1, 2f);
        DrawLS(AerialNode, RSU2, 2f);
        DrawLS(AerialNode, RSU3, 2f);
        DrawLS(AerialNode, RSU4, 2f);
        DrawLS(AerialNode, RSU5, 2f);
        DrawLS(AerialNode, RSU6, 2f);
        DrawLS(AerialNode, RSU7, 2f);
        DrawLS(AerialNode, RSU8, 2f);
        DrawLS(AerialNode, RSU9, 2f);
        DrawLS(AerialNode, RSU10, 2f);
        DrawLS(AerialNode, BS1, 2f);
        DrawLS(AerialNode, BS2, 2f);
        DrawLS(AerialNode, BS3, 2f);
        DrawLS(AerialNode, BS4, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawLS(Transform startP, Transform finalP,float LThickness)
    {
        Vector3 rightPosition = (startP.position + finalP.transform.position) / 2;
        Vector3 rightRotation = finalP.position - startP.transform.position;
        float HalfLength = Vector3.Distance(startP.position, finalP.position) / 2;

        //创建圆柱体
        GameObject MyLine = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        MyLine.gameObject.transform.parent = transform;
        MyLine.transform.position = rightPosition;
        MyLine.transform.rotation = Quaternion.FromToRotation(Vector3.up, rightRotation);
        MyLine.transform.localScale = new Vector3(LThickness, HalfLength, LThickness);

        //这里可以设置材质，具体自己设置
        LineMesh = MyLine.GetComponent<MeshRenderer>();
        LineMesh.material = LineMaterial;
        LineMesh.shadowCastingMode = ShadowCastingMode.Off;
        LineMesh.receiveShadows = false;
    }
}
