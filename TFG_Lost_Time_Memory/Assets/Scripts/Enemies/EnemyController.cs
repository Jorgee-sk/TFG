using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int detectionRange;
    [SerializeField] private int attackRange;
    [SerializeField] private int attackDamage;
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationModifier;
    [SerializeField] private bool activeRotation;

    public CustomImages customImages;
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private NavMeshAgent _navMeshAgent;

    public static EnemyController Instance { get; private set; }

    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }

    public int AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }

    public int DetectionRange
    {
        get => detectionRange;
        set => detectionRange = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        CheckPlayerImage();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Ahora mismo este codigo no se usa
        if (activeRotation)
        {
            _direction = (target.transform.position - transform.position);
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Death();
        }
    }


    private void Death()
    {
        Destroy(gameObject);
    }

    void CheckPlayerImage()
    {
        string directorioOriginal = Application.dataPath + "\\Images";
        string directorio = Application.dataPath + "\\Images\\ResultImages";

        if (customImages.enemyImageToSet == null || customImages.enemyImageToSet.Equals(""))
        {
            if (Directory.Exists(directorioOriginal))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals("enemy.png"))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f));

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
                    if (archivoPNG.Name.Equals(customImages.enemyImageToSet))
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

                            float scaleX = 1 / (loadTextureWidth * 2);
                            float scaleY = 1 / (loadTextureHeight * 2);

                            transform.localScale = new Vector3(scaleX, scaleY, 1);
                        }
                        else
                        {
                            float scale = 0.5f;
                            transform.localScale = new Vector3(scale, scale, 1);
                        }

                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        break;
                    }
                    else
                    {
                        float scale = 0.5f;
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