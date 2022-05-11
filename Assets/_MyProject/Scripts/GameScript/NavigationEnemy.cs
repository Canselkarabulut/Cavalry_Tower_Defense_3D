using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavigationEnemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent _nMesh;// Navigasyonu tanımladık
    void Awake()
    {
        _nMesh = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        _nMesh.destination = target.transform.position;  // varıs pozisyonunu veriyoruz.
    }   
}
