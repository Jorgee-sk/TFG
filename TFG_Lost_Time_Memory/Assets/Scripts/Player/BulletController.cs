using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLifeTime;
    public int bulletDmg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletDeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator BulletDeathDelay()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            col.gameObject.GetComponent<EnemyController>().ReceiveDamage(bulletDmg);
            Destroy(gameObject);
        }
        else if (col.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
    }
}