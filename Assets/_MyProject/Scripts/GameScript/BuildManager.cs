using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] public GameObject standartTurretPrefab;
    [SerializeField] public GameObject MissileLauncherPrefab;
    TurretBlueprint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("baþka yere ekle");

        }
        instance = this;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    GameObject turret;
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
        }
        else
        {
            turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            PlayerStats.money -= turretToBuild.cost;
        }
        node.turret = turret;


        Debug.Log("Turret build! Money left : " + PlayerStats.money);


    }

}
