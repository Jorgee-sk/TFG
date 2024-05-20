using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] private string keyName;
    [SerializeField] private string defaultPicName;
    
    // Start is called before the first frame update
    void Start()
    {
        CheckImage(1f,gameObject);
    }

    void CheckImage(float scale, GameObject mapGameObject)
    {
        string directorioOriginal = Directory.GetCurrentDirectory() + "\\Assets\\Images\\GameButtons";
        string directorio = Directory.GetCurrentDirectory() + "\\Assets\\Images\\ResultImages";
        string directorioInit = Directory.GetCurrentDirectory() + "\\Assets\\Images\\InGameImages";

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

                        mapGameObject.GetComponent<Image>().sprite = currentSprite;

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

                bool existe = false;

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals(PlayerPrefs.GetString(keyName)))
                    {
                        existe = true;
                    }
                }

                if (!existe && Directory.Exists(directorioInit))
                {
                    directorioInfo = new DirectoryInfo(directorioInit);
                    archivosPNG = directorioInfo.GetFiles("*.png");
                }


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

                        mapGameObject.GetComponent<Image>().sprite = currentSprite;
                        mapGameObject.transform.localScale = new Vector3(scale, scale, 1);

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