using System.Collections;
using System.IO;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLifeTime;
    public int bulletDmg;
    private Vector2 _colliderSize;
    
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        _colliderSize = boxCollider2D.size;
        CheckPlayerImage();
        StartCoroutine(BulletDeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator BulletDeathDelay()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            col.gameObject.GetComponent<EnemyController>().Health -= bulletDmg;

            if (col.gameObject.GetComponent<EnemyController>().Health == 0)
            {
                PlayerController.Score += 1000;
                col.gameObject.SetActive(false);
            }

            gameObject.SetActive(false);
        }
        else if (col.tag.Equals("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

    void CheckPlayerImage()
    {
        string directorioOriginal = Directory.GetCurrentDirectory() + "\\Assets\\Images";
        string directorio = Directory.GetCurrentDirectory() + "\\Assets\\Images\\InGameImages";

        if (PlayerPrefs.GetString("bulletImage") == null ||
            PlayerPrefs.GetString("bulletImage").Equals(""))
        {
            if (Directory.Exists(directorioOriginal))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals("bullet.png"))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f));

                        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
                        boxCollider2D.size = _colliderSize;

                        float scale = 0.125f;

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
                    if (archivoPNG.Name.Equals(PlayerPrefs.GetString("bulletImage")))
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
}