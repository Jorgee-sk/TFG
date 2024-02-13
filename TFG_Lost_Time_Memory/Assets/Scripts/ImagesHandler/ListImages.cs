using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListImages : MonoBehaviour
{
    public List<Sprite> gallery;
    public List<string> imageNames;
    public Image currentImage;
    public Button nextImg;
    public Button prevImg;
    public Button deleteImg;
    public int currentIdx;
    public TMP_Text currentImageTxt;

    public List<string> fullPathImageNames;
    //public List<Sprite> Gallery => gallery;
    //public List<string> TxtImagesNames => imageNames;

    void Start()
    {
        string directorio = Application.dataPath + "\\Images\\InGameImages";
        PrincipalGalleryImageHandler(directorio);
    }

    /**
     * Verificamos si existe un directorio o no, en caso de existir
     * creamos un objeto directory info que nos permite obtener los ficheros por extensión
     * y una vez obtenidos los recorremos añadiendo los sprites a la lista de la galería principal
     */
    private void PrincipalGalleryImageHandler(string directorio)
    {
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
            }

            if (gallery is { Count: > 0 })
            {
                currentImage.sprite = gallery[0];
                currentImageTxt.SetText(imageNames[0]);
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

        fullPathImageNames.Add(archivoPNG.FullName);
        imageNames.Add(archivoPNG.Name);
        gallery.Add(currentSprite);
    }

    void OnEnable()
    {
        nextImg.onClick.AddListener(() => NextImgButton());
        prevImg.onClick.AddListener(() => PreviousImgButton());
        deleteImg.onClick.AddListener(() => DeleteCurrentImg());
    }


    void NextImgButton()
    {
        if (currentIdx + 1 < gallery.Count)
        {
            currentIdx++;
        }

        if (gallery is { Count: > 0 })
        {
            currentImageTxt.SetText(imageNames[currentIdx]);
            currentImage.sprite = gallery[currentIdx];
        }
    }

    void PreviousImgButton()
    {
        if (currentIdx - 1 >= 0)
        {
            currentIdx--;
        }

        if (gallery is { Count: > 0 })
        {
            currentImageTxt.SetText(imageNames[currentIdx]);
            currentImage.sprite = gallery[currentIdx];
        }
    }

    void DeleteCurrentImg()
    {
        if (gallery is { Count: > 0 } && gallery[currentIdx] != null)
        {
            imageNames.RemoveAt(currentIdx);
            gallery.RemoveAt(currentIdx);
            File.Delete(fullPathImageNames[currentIdx]);
            fullPathImageNames.RemoveAt(currentIdx);

            if (currentIdx + 1 < gallery.Count)
            {
                currentIdx++;
            }

            if (currentIdx - 1 >= 0)
            {
                currentIdx--;
            }

            currentImageTxt.SetText(imageNames[currentIdx]);
            currentImage.sprite = gallery[currentIdx];
        }
    }

    public string GetCurrentImageName()
    {
        return imageNames[currentIdx];
    }
}