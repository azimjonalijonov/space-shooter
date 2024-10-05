using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 startDirection;
    public bool shouldChangeDirection;
    public float changeDirectionXPoint;
    public Vector2 changedDirection;

    public GameObject shotToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    public bool canShoot;
    private bool allowShooting;

    public int currentHealth;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldChangeDirection)
        {
            transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            if (transform.position.x > changeDirectionXPoint)
            {
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                transform.position += new Vector3(changedDirection.x * moveSpeed * Time.deltaTime, changedDirection.y * moveSpeed * Time.deltaTime, 0f);
            }
        }

        if (allowShooting)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Instantiate(shotToFire, firePoint.position, firePoint.rotation);
            }
        }

          
    }

    public void HurtEnemy()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        if (canShoot)
        {
            allowShooting = true;
        }
    }
}
