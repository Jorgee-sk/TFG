using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ListImages : MonoBehaviour
{
    public List<Sprite> gallery;
    public List<string> imageNames;
    public Image currentImage;
    public Button nextImg;
    public Button prevImg;
    public int currentIdx;

    public List<Sprite> Gallery => gallery;

    void Start()
    {
        string directorio = Application.dataPath + "\\Images\\InGameImages";

        // Verificar si el directorio existe
        if (Directory.Exists(directorio))
        {
            // Crear un objeto DirectoryInfo
            DirectoryInfo directorioInfo = new DirectoryInfo(directorio);

            // Obtener solo los archivos PNG en el directorio
            FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

            // Imprimir los nombres de los archivos PNG
            foreach (FileInfo archivoPNG in archivosPNG)
            {
                SetCurrentSpriteFromFile(archivoPNG);
                Debug.Log("Archivo PNG: " + archivoPNG.FullName);
            }

            if (gallery[0] != null)
            {
                currentImage.sprite = gallery[0];
            }
        }
        else
        {
            Debug.LogError("El directorio no existe: " + directorio);
        }
    }

    /**
     * Añadir los datos a la galería a partir de un path con el que
     * se obtienen los bytes y se genera una textura que construirá
     * el sprite que se va a añadir a la lista final.
     */
    private void SetCurrentSpriteFromFile(FileInfo archivoPNG)
    {
        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
        Texture2D loadTexture = new Texture2D(1, 1);
        loadTexture.LoadImage(bytes);

        Sprite currentSprite = Sprite.Create(loadTexture, new Rect(0, 0, loadTexture.width, loadTexture.height),
            Vector2.zero);

        imageNames.Add(archivoPNG.Name);
        gallery.Add(currentSprite);
    }

    void OnEnable()
    {
        nextImg.onClick.AddListener(() => NextImgButton());
        prevImg.onClick.AddListener(() => PreviousImgButton());
    }


    void NextImgButton()
    {
        if (currentIdx + 1 < gallery.Count)
        {
            currentIdx++;
        }

        currentImage.sprite = gallery[currentIdx];
    }

    void PreviousImgButton()
    {
        if (currentIdx - 1 >= 0)
        {
            currentIdx--;
        }

        currentImage.sprite = gallery[currentIdx];
    }
}