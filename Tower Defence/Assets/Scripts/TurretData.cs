using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData
{
    public GameObject TurretPrefab;
    public int Cost;
    public GameObject UpgradeTurretPrefab;
    public int UpgradeCost;
    public int Value;
    public int UpgradeValue;
}

public enum TurretType
{
    LaserTurret,MissileTurret,StandardTurret
}