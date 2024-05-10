using System.IO;
using UnityEngine;

public class MapObjectsController : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject[] walls;

    // Start is called before the first frame update
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            CheckPlayerImage(1f, wall, "tileImage", "tiledWall.png");
        }

        CheckPlayerImage(1f, background, "bgImage", "suelo.png");
    }

    void CheckPlayerImage(float scale, GameObject mapGameObject, string keyName, string defaultPicName)
    {
        string directorioOriginal = Directory.GetCurrentDirectory() + "\\Assets\\Images";
        string directorio = Directory.GetCurrentDirectory() + "\\Assets\\ResultImages";
   
        if (PlayerPrefs.GetString(keyName) == null || PlayerPrefs.GetString(keyName).Equals(""))
        {
            if (Directory.Exists(directorioOriginal))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals(defaultPicName))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);
                        
                        //Es importante que el ppu esté a 256 por que es lo que hace que el tile cuadre en estos casos
                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f), 256f);

                        mapGameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;

                        mapGameObject.transform.localScale = new Vector3(scale, scale, 1);
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
                    if (archivoPNG.Name.Equals(PlayerPrefs.GetString(keyName)))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f), 256f);

                        mapGameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;

                        if (loadTexture.width != 256 || loadTexture.height != 256)
                        {
                            float textureSizeXY = 256f;
                            float loadTextureWidth = loadTexture.width / textureSizeXY;
                            float loadTextureHeight = loadTexture.height / textureSizeXY;

                            float scaleX = 1 / (loadTextureWidth * 2);
                            float scaleY = 1 / (loadTextureHeight * 2);

                            mapGameObject.transform.localScale = new Vector3(scaleX, scaleY, 1);
                        }
                        else
                        {
                            mapGameObject.transform.localScale = new Vector3(scale, scale, 1);
                        }

                        break;
                    }
                    else
                    {
                        mapGameObject.transform.localScale = new Vector3(scale, scale, 1);
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