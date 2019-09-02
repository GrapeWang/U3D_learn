using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject TurretOn;

    public bool isUpgraded = false;

    public GameObject BuildEffect;
    private GameObject effect;
    private Renderer render;
    [HideInInspector]
    public TurretData turretData;

    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        isUpgraded = false;
        TurretOn = GameObject.Instantiate(turretData.TurretPrefab, transform.position, Quaternion.identity);
        effect = GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(effect,1.5f);
    }

    public void UpgradeTurret()
    {
        if (isUpgraded)
        {
            return;
        }
        Destroy(TurretOn);
        isUpgraded = true;
        TurretOn = GameObject.Instantiate(turretData.UpgradeTurretPrefab, transform.position, Quaternion.identity);
        effect = GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void DestroyTurret()
    {
        Destroy(TurretOn);
        isUpgraded = false;
        TurretOn = null;
        turretData = null;
        effect = GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }


    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (TurretOn == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            render.material.color = Color.green;
        }
    }

    void OnMouseExit()
    {
        render.material.color = Color.white;
    }
}
