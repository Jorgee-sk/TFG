using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Dictionary<ItemsEnum, bool> _powerUpDictionary;
    public TMP_Text scoreText;
    public AudioClip coinClip;
    public List<GameObject> prefabToSpawnList;
    public GameObject spawnPointsFather;

    private List<Vector3> _childPositions;
    private GameObject _prefabToSpawn;
    private int _scoreIterator = 10000;
    public float spawnInterval = 20f;
    private float _timer;


    // Start is called before the first frame update
    void Awake()
    {

        foreach (GameObject prefabToSpawn in prefabToSpawnList)
        {
            prefabToSpawn.GetComponent<ItemsController>().SetPowerUpManager(GetComponent<PowerUpManager>());
        }
        
        _powerUpDictionary = new Dictionary<ItemsEnum, bool>
        {
            { ItemsEnum.speedPowerUp, false },
            { ItemsEnum.plusOneHP, false },
            { ItemsEnum.shootSpeed, false },
            { ItemsEnum.coin, false }
        };
    }

    void Start()
    {
        _childPositions = GetAllChildrenPositions(spawnPointsFather.transform);
    }

    List<Vector3> GetAllChildrenPositions(Transform t)
    {
        List<Vector3> positions = new List<Vector3>();

        Transform[] componentsInChildren = t.GetComponentsInChildren<Transform>();

        for (int i = 1; i < componentsInChildren.Length; i++)
        {
            positions.Add(componentsInChildren[i].position);
        }
        
        positions.Add(Vector3.zero);
        
        return positions;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (PlayerController.Score > _scoreIterator)
        {
            if (spawnInterval > 10)
            {
                spawnInterval -= 5;
            }
            _scoreIterator += 10000;
        }
        
        
        if (_timer >= spawnInterval)
        {
            _prefabToSpawn = prefabToSpawnList[Random.Range(1, 3)];

            int range = Random.Range(1, _childPositions.Count);
            Vector3 instancePosition = _childPositions[range];
            _childPositions.RemoveAt(range);
            
            GameObject instanciated = Instantiate(_prefabToSpawn, instancePosition, Quaternion.identity);

            StartCoroutine(DestroyAfterSeconds(instanciated));
            _childPositions.Add(instancePosition);

            _timer = 0f;
        }
    }

    private IEnumerator DestroyAfterSeconds(GameObject instanciated)
    {
        yield return new WaitForSeconds(10f);
        Destroy(instanciated);
    }
    
    

    public bool PowerUpHandler(ItemsEnum powerUpType, GameObject gameObject)
    {
        if (powerUpType == ItemsEnum.coin && !_powerUpDictionary[ItemsEnum.coin])
        {
            _powerUpDictionary[ItemsEnum.coin] = true;
            StartCoroutine(GetCoin(gameObject, 15f));
            _powerUpDictionary[ItemsEnum.coin] = false;
            return true;
        }
        
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

    private IEnumerator GetCoin(GameObject coin, float seconds)
    {
        PlayerController.Score += 100;

        //Si se le añade un parámetro más en float, es el volumen
        AudioSource.PlayClipAtPoint(coinClip, coin.transform.position);
        scoreText.text = "SCORE: " + PlayerController.Score;

        coin.SetActive(false);
        yield return new WaitForSeconds(seconds);
        coin.SetActive(true);
    }

    private static void HealPlayer()
    {
        PlayerController.Health = Mathf.Min(PlayerController.MaxHealth, PlayerController.Health + 1);
    }
}