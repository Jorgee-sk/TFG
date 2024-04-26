using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private ItemsEnum typeOfPowerUp;
    [SerializeField] private PowerUpManager powerUpManager;

    public void SetPowerUpManager(PowerUpManager script)
    {
        powerUpManager = script;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            if (powerUpManager.PowerUpHandler(typeOfPowerUp, gameObject))
            {
                gameObject.SetActive(false);
            }
        }
    }
}