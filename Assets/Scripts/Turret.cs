using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Setup")]
    public string enemyTag = "Enemy";
    public Transform Rotater;
    public float turnSpeed = 10f;
    public GameObject bulletFab;
    public Transform firePointLeft;
    public Transform firePointRight;

	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget ()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

	void Update () {

        if (target == null)
            return;


        //Target Lockon
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Rotater.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Rotater.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Shoot(){
        GameObject bulletRight = (GameObject) Instantiate(bulletFab, firePointRight.position, firePointRight.rotation);
        GameObject bulletLeft =  (GameObject) Instantiate(bulletFab, firePointLeft.position, firePointLeft.rotation);

        Bullet bulletR = bulletRight.GetComponent<Bullet>();
        Bullet bulletL = bulletLeft.GetComponent<Bullet>();

        if (bulletR != null || bulletL != null){
            bulletR.Seek(target);
            bulletL.Seek(target);
        }
    }

     void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
