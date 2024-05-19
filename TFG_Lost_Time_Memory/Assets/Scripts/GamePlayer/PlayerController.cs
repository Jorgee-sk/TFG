using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static float _speed;
    private Rigidbody2D _rigidbody2D;
    private float _lastFire;
    public BgPoolController bgPoolController;
    private static float _defaultSpeed = 7f;
    private static int _maxHealth = 10;
    private static int _health = 10;
    private static int _score = 0;
    //[SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    private static float _maxFireDelay = 0.6f;
    private static float _fireDelay = 0.6f;
    private Vector2 _colliderSize;
    [SerializeField] private Sprite[] _sprites;
    private Animator spriteAnimator;

    public static float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public static int Health
    {
        get => _health;
        set => _health = value;
    }

    public static float FireDelay
    {
        get => _fireDelay;
        set => _fireDelay = value;
    }

    public static float MaxFireDelay
    {
        get => _maxFireDelay;
        set => _maxFireDelay = value;
    }

    public static int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public static float DefaultSpeed
    {
        get => _defaultSpeed;
        set => _defaultSpeed = value;
    }

    public static int Score
    {
        get => _score;
        set => _score = value;
    }

    void Start()
    {
        SetDefaultStats();
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        _colliderSize = boxCollider2D.size;
        if (PlayerPrefs.GetInt("AnimatedGraphics") == 0)
        {
            CheckPlayerImage();
            GetComponent<Animator>().enabled = false;
        }
        else
        {
            LoadBaseAnimatedSpriteImage();
            GetComponent<Animator>().enabled = true;
            spriteAnimator = GetComponent<Animator>();
        }
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed = _defaultSpeed;
    }

    void SetDefaultStats()
    {
        _score = 0;
        _health = 10;
        _defaultSpeed = 7f;
        _fireDelay = 0.6f;
        Time.timeScale = 1f;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xShoot = Input.GetAxis("ShootHorizontal");
        float yShoot = Input.GetAxis("ShootVertical");

        if ((xShoot != 0 || yShoot != 0) && Time.time > _lastFire + _fireDelay)
        {
            Shoot(xShoot, yShoot, x, y);
            _lastFire = Time.time;
        }

        _rigidbody2D.velocity = new Vector2(x * _speed, y * _speed);

        if (PlayerPrefs.GetInt("AnimatedGraphics") == 1 && spriteAnimator != null)
        {
            if (x != 0 || y != 0)
            {
                spriteAnimator.SetFloat("MoveX",x);
                spriteAnimator.SetFloat("MoveY",y);
                spriteAnimator.SetBool("IsWalking",true);
            }
            else
            {
                spriteAnimator.SetBool("IsWalking",false);
            }

        }
    }

    void Shoot(float xShoot, float yShoot, float xDirection, float yDirection)
    {
        Transform playerTransform = transform;
        GameObject bulletToShoot = bgPoolController.GetPooledObject();
        AudioSource.PlayClipAtPoint(bulletToShoot.GetComponent<AudioSource>().clip, transform.position);
        if (bulletToShoot != null)
        {
            bulletToShoot.transform.position = playerTransform.position;
            bulletToShoot.transform.rotation = playerTransform.rotation;
            bulletToShoot.SetActive(true);

            float auxBulletSpeedX = 1f;
            float auxBulletSpeedY = 1f;
            if ((xShoot < 0 && xDirection < 0) || (xDirection > 0 && xShoot > 0))
            {
                auxBulletSpeedX = 1.4f;
            }

            if ((yShoot < 0 && yDirection < 0) || (yDirection > 0 && yShoot > 0))
            {
                auxBulletSpeedY = 1.4f;
            }

            bulletToShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(
                xShoot < 0
                    ? Mathf.Floor(xShoot) * bulletSpeed * auxBulletSpeedX
                    : Mathf.Ceil(xShoot) * bulletSpeed * auxBulletSpeedX,
                yShoot < 0
                    ? Mathf.Floor(yShoot) * bulletSpeed * auxBulletSpeedY
                    : Mathf.Ceil(yShoot) * bulletSpeed * auxBulletSpeedY
            );
        }
    }

    void LoadBaseAnimatedSpriteImage()
    {
        string directorioOriginal = Directory.GetCurrentDirectory() + "\\Assets\\Images\\BaseImages";
        
        DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

        FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

        foreach (FileInfo archivoPNG in archivosPNG)
        {
            if (archivoPNG.Name.Equals("playerAnimated.png"))
            {
                byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                Texture2D loadTexture = new Texture2D(1, 1);
                loadTexture.LoadImage(bytes);
                
                Sprite currentSprite = _sprites[0];


                float scale = 2.5f;

                GetComponent<SpriteRenderer>().sprite = currentSprite;
                transform.localScale = new Vector3(scale, scale, 1);
                GetComponent<BoxCollider2D>().size = new Vector2(0.39f, 0.45f);
                break;
            }
        }
    }

    void CheckPlayerImage()
    {
        
        string directorioOriginal = Directory.GetCurrentDirectory() + "\\Assets\\Images\\BaseImages";
        string directorio = Directory.GetCurrentDirectory() + "\\Assets\\Images\\ResultImages";

        if (PlayerPrefs.GetString("playerImage") == null || PlayerPrefs.GetString("playerImage").Equals(""))
        {
            if (Directory.Exists(directorioOriginal))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals("player.png"))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f));

                        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
                        boxCollider2D.size = _colliderSize;

                        float scale = 0.5f;
                        
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
                    if (archivoPNG.Name.Equals(PlayerPrefs.GetString("playerImage")))
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

                            float scaleX = 1 / (loadTextureWidth*2);
                            float scaleY = 1 / (loadTextureHeight*2);

                            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
                            Vector2 colliderSize = boxCollider2D.size;
                            boxCollider2D.size = new Vector2(colliderSize.x * loadTextureWidth,
                                colliderSize.y * loadTextureHeight);

                            transform.localScale = new Vector3(scaleX, scaleY, 1);
                        }
                        else
                        {
                            float scale = 0.5f;
                            transform.localScale = new Vector3(scale, scale, 1);
                        }
                        break;
                    }
                }
            }
            else
            {
                Debug.LogError("El directorio no existe: " + directorio);
            }
        }
    }

    public static void StopGame()
    {
        Time.timeScale = 0f;
        GameObject g = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g => g.CompareTag("ExitMenu"));
        g.SetActive(true);
    }

    public int GetScore()
    {
        return _score;
    }
}