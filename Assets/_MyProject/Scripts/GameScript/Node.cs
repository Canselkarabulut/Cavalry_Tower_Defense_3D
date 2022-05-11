using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColoer;
    Renderer rend;
    Color startColor;
    [SerializeField] Color notEnoughMoneyColor;
    [SerializeField] GameObject spawnTurret;
    [SerializeField] Vector3 positionOffset;
    BuildManager buildManager;
    [Header("Optional")]
    public GameObject turret;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColoer;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if (!gameObject.CompareTag("Cube"))
            return;
        if (PlayerStats.money > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }


            if (!buildManager.CanBuild)
            {
                return;
            }
            if (turret != null)
            {
                Debug.Log("koyamazsýn makineni");
            }
            buildManager.BuildTurretOn(this);
        }
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
