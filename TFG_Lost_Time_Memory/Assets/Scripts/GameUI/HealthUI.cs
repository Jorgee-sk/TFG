using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject heartContainer;
    private float _fillValue;
    private float _maxHealth = 10;


    // Update is called once per frame
    void Update()
    {
        _fillValue = PlayerController.Health;
        _fillValue /= _maxHealth;
        heartContainer.GetComponent<Image>().fillAmount = _fillValue;
    }
}