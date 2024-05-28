using System.IO;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private ItemsEnum typeOfPowerUp;
    [SerializeField] private PowerUpManager powerUpManager;
    private string _defaultPicName;
    private string _powerUpKeyName;

    private void Start()
    {
        if (typeOfPowerUp == ItemsEnum.coin) //Carga las imágenes monedas al inicio
        {
            PowerUpPicNameSetter();
            CheckPlayerImage(0.15f);
        }
    }

    public void SetPowerUpManager(PowerUpManager script)
    {
        powerUpManager = script;
        PowerUpPicNameSetter();  //Carga el resto de powerups
        CheckPlayerImage(0.2f);
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

    void PowerUpPicNameSetter()
    {
        if (typeOfPowerUp == ItemsEnum.coin)
        {
            _defaultPicName = "scoreItem.png";
            _powerUpKeyName = "scoreItemImage";
        }
        else if (typeOfPowerUp == ItemsEnum.shootSpeed)
        {
            _defaultPicName = "shootSpeed.png";
            _powerUpKeyName = "shootPowerUpImage";
        }
        else if (typeOfPowerUp == ItemsEnum.speedPowerUp)
        {
            _defaultPicName = "speedItem.png";
            _powerUpKeyName = "speedPowerUpImage";
        }
        else if (typeOfPowerUp == ItemsEnum.plusOneHP)
        {
            _defaultPicName = "Heart.png";
            _powerUpKeyName = "lifePowerUpImage";
        }
            
    }
    
     void CheckPlayerImage(float scale)
    {
        string directorioOriginal = Directory.GetCurrentDirectory() + "\\Assets\\Images\\BaseImages";
        string directorio = Directory.GetCurrentDirectory() + "\\Assets\\Images\\ResultImages";

        if (PlayerPrefs.GetString(_powerUpKeyName) == null || PlayerPrefs.GetString(_powerUpKeyName).Equals(""))
        {
            if (Directory.Exists(directorioOriginal))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals(_defaultPicName))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f));

                        GetComponent<SpriteRenderer>().sprite = currentSprite;
                        transform.localScale = new Vector3(scale, scale, 1);
                        break;
                    }
                }
            }
            else
            {
                Debug.LogError("El directorio no existe: " + directorio);
            }
        }
        else
        {
            if (Directory.Exists(directorio))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorio);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals(PlayerPrefs.GetString(_powerUpKeyName)))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f));

                        GetComponent<SpriteRenderer>().sprite = currentSprite;

                        if (loadTexture.width != 256 || loadTexture.height != 256)
                        {
                            float textureSizeXY = 256f;
                            float loadTextureWidth = loadTexture.width / textureSizeXY;
                            float loadTextureHeight = loadTexture.height / textureSizeXY;

                            float scaleX = 1 / (loadTextureWidth * 4);
                            float scaleY = 1 / (loadTextureHeight * 4);

                            transform.localScale = new Vector3(scaleX, scaleY, 1);
                        }
                        else
                        {
                            transform.localScale = new Vector3(scale, scale, 1);
                        }
                        
                        break;
                    }
                    else
                    {
                        
                        transform.localScale = new Vector3(scale, scale, 1);
                    }
                }
            }
            else
            {
                Debug.LogError("El directorio no existe: " + directorio);
            }
        }
    }
}