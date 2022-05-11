using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed = 70f;
    [SerializeField] GameObject impactEffect;
 
    void Update()
    {
        DirectionBullet();
    }
    //-------------------------------------------------------------------------------------------------
    public void Seek(Transform _target)
    {
        target = _target;
    }
    public void DirectionBullet()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    private void HitTarget()
    {
        GameObject effectIns =  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
      
        Destroy(gameObject);
        
    }
}
