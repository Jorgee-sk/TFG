using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Dictionary<ItemsEnum, bool> _powerUpDictionary;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpDictionary = new Dictionary<ItemsEnum, bool>
        {
            { ItemsEnum.speedPowerUp, false },
            { ItemsEnum.plusOneHP, false },
            { ItemsEnum.shootSpeed , false}
        };
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool PowerUpHandler(ItemsEnum powerUpType)
    {
        if (powerUpType == ItemsEnum.speedPowerUp && !_powerUpDictionary[ItemsEnum.speedPowerUp])
        {
            //Hacemos que cuando entra aquí no pueda coger un power up de velocidad
            _powerUpDictionary[ItemsEnum.speedPowerUp] = true;
            StartCoroutine(SpeedPowerUp(5));
            //Hacemos que cuando termine de ejecutar la corutina, ya pueda volver a entrar
            _powerUpDictionary[ItemsEnum.speedPowerUp] = false;
            return true;
        }

        if (powerUpType == ItemsEnum.plusOneHP && !_powerUpDictionary[ItemsEnum.plusOneHP])
        {
            if (PlayerController.Health.Equals(PlayerController.MaxHealth))
            {
                return false;
            }

            _powerUpDictionary[ItemsEnum.plusOneHP] = true;
            HealPlayer();
            _powerUpDictionary[ItemsEnum.plusOneHP] = false;
            return true;
        }

        if (powerUpType == ItemsEnum.shootSpeed && !_powerUpDictionary[ItemsEnum.shootSpeed])
        {
            _powerUpDictionary[ItemsEnum.shootSpeed] = true;
            StartCoroutine(BulletSpeedPowerUp(3f));
            _powerUpDictionary[ItemsEnum.shootSpeed] = false;
            return true;
        }

        return false;
    }

    private IEnumerator SpeedPowerUp(float seconds)
    {
        PlayerController.Speed = 9;
        yield return new WaitForSeconds(seconds);
        PlayerController.Speed = PlayerController.DefaultSpeed;
    }
    
    private IEnumerator BulletSpeedPowerUp(float seconds)
    {
        PlayerController.FireDelay = 0.2f;
        yield return new WaitForSeconds(seconds);
        PlayerController.FireDelay = PlayerController.MaxFireDelay;
    }

    private static void HealPlayer()
    {

        PlayerController.Health = Mathf.Min(PlayerController.MaxHealth, PlayerController.Health + 1);
    }
}