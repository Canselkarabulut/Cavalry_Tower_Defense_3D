using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float range = 60f; // Kapsama alaný
    [SerializeField] float fireRate = 1f;
    float fireCountDown = 0f;
    [Header("Unity Setup Fields")]
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] Transform rotatingBase;
    [SerializeField] float turnSpeed = 10f;
    Transform target;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    void Start()
    {
        InvokeRepeatingCall();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TargetLookOn();
        }
    }

    private void OnDrawGizmosSelected() //Atýþ Kapsama alaný belirleyen method
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    //--------------------------------------------------------------------------------------------------------

    void TargetLookOn()
    {
        if (target == null)
            return;
        //Target Look on
        Vector3 direction = target.position - transform.position; //Turrent'in enemy'i takip etmesi;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatingBase.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingBase.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

        //Ateþ Etme alaný
        if (fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    void InvokeRepeatingCall()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortesDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortesDistance)
                {
                    shortesDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            if (nearestEnemy != null && shortesDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        
    }
    /// ----------------Shoot
    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
            PlayerStats.money += 20;
        }
    }
}
