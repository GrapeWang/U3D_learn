using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretData LaserTurretData;
    public TurretData MissileTurretData;
    public TurretData StandardTurretData;
    public Text MoneyText;
    public Text UpgradeCost;
    public Text DestroyValue;
    public Animator MoneyAnimator;
    public Animator UpgradeUIAnimator;
    public GameObject UpgradeUI;
    public Button UpgradeButton;
    private TurretData SelectedTurretData;
    private GameObject SelectedTurret;
    private MapCube currentMap;
    private RaycastHit hitinfo;
    private Vector3 offset = new Vector3(0,1.2f,0);
    private bool isUpgradeUIHide=true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitinfo, 1000f, LayerMask.GetMask("MapCube")))
                {
                    currentMap = hitinfo.collider.gameObject.GetComponent<MapCube>();
                    if (SelectedTurretData != null&&currentMap.TurretOn==null)
                    {
                        //create turret
                        if (DataManager.money >= SelectedTurretData.Cost)
                        {
                            MoneyChange(-SelectedTurretData.Cost);
                            currentMap.BuildTurret(SelectedTurretData);
                        }
                        else
                        {
                            MoneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (currentMap.TurretOn != null)
                    {
                        //upgrade turret
                        
                        if (SelectedTurret==currentMap.TurretOn && isUpgradeUIHide == false)
                        {
                            HideUpgradeUI();
                        }
                        else
                        {
                            if (currentMap.isUpgraded == false)
                            {
                                UpgradeCost.text = "-" + currentMap.turretData.UpgradeCost + "￥";
                                DestroyValue.text = "+" + currentMap.turretData.Value + "￥";
                                ShowUpgradeUI(currentMap.transform.position, currentMap.isUpgraded);
                            }
                            else
                            {
                                UpgradeCost.text = null;
                                DestroyValue.text = "+" + currentMap.turretData.UpgradeValue + "￥";
                                ShowUpgradeUI(currentMap.transform.position + offset, currentMap.isUpgraded);
                            }
                        }
                        SelectedTurret = currentMap.TurretOn;
                    }
                }
            }
        }
        
    }

    public void MoneyChange(int change)
    {
        DataManager.money += change;
        MoneyText.text = "￥" + DataManager.money;
    }

    public void OnlaserSelected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = LaserTurretData;
        }
    }

    public void OnmissileSelected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = MissileTurretData;
        }
    }

    public void OnstandardSelected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = StandardTurretData;
        }
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisabled=false)
    {
        UpgradeUI.SetActive(false);
        UpgradeUI.SetActive(true);
        UpgradeUI.transform.position = pos;
        UpgradeButton.interactable = !isDisabled;
        isUpgradeUIHide = false;
    }

    void HideUpgradeUI()
    {
        //UpgradeUI.SetActive(false);
        UpgradeUIAnimator.SetTrigger("hide");
        isUpgradeUIHide = true;
    }

    public void onUpgradeButtonDown()
    {
        if (DataManager.money>=currentMap.turretData.UpgradeCost)
        {
            currentMap.UpgradeTurret();
            HideUpgradeUI();
            currentMap.isUpgraded = true;
            MoneyChange(-currentMap.turretData.UpgradeCost);
        }
        else
        {
            MoneyAnimator.SetTrigger("Flicker");
        }
        
    }

    public void onDestroyButtonDown()
    {
        if (currentMap.isUpgraded)
        {
            MoneyChange(currentMap.turretData.UpgradeValue);
        }
        else
        {
            MoneyChange(currentMap.turretData.Value);
        }
        currentMap.DestroyTurret();
        HideUpgradeUI();
        currentMap.isUpgraded = false;
    }
}
