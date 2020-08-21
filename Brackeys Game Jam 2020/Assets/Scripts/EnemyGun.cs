using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject enemyBullet;

    float fireRate;
    float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToFire();
    }

    void CheckTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

}
