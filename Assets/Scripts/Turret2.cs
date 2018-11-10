using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret2 : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    float rotation = 20f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;

    [Header("Setup")]
    public string enemyTag = "Enemy";
    public GameObject bulletFab;
    public Transform firePoint;
    private AudioSource fireSFX;
    private float pitchLow = 0.8f;
    private float pitchHigh = 1.1f;

    void Start () {
        fireSFX = GetComponent<AudioSource>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }
    //Makes RailGun Traggable
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotation * Mathf.Deg2Rad * 10;
        transform.Rotate(Vector3.up, rotX);      
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }
    }
    // Update is called once per frame
    void Update () {

        if (target == null)
            return;
        if (fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletShoot = (GameObject)Instantiate(bulletFab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletShoot.GetComponent<Bullet>();
        fireSFX.pitch = Random.Range(pitchLow,pitchHigh);
        fireSFX.Play();
        Destroy(bulletShoot, 1);
      //  if (bullet != null)
          //  bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
