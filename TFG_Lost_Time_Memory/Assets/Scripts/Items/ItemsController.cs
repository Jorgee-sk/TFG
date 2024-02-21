using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private ItemsEnum typeOfPowerUp;
    [SerializeField] private PowerUpManager powerUpManager;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            if (powerUpManager.PowerUpHandler(typeOfPowerUp))
            {
                Destroy(gameObject);
            }
        }
    }
}