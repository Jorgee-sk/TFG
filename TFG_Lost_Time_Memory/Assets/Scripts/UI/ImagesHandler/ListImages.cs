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
    public GameObject nextImage;
    public GameObject prevImage;

    public GameObject imgBgNext;
    public GameObject imgBgPrev;
    
    public Button nextImg;
    public Button prevImg;
    public Button deleteImg;
    public int currentIdx;
    public TMP_Text currentImageTxt;
    public bool pngGallery;

    public List<string> fullPathImageNames;

    void OnEnable()
    {
        gallery = new List<Sprite>();
        imageNames = new List<string>();
        currentIdx = 0;

        nextImg.onClick.RemoveAllListeners();
        prevImg.onClick.RemoveAllListeners();
        deleteImg.onClick.RemoveAllListeners();

        string directorio = !pngGallery
            ? Directory.GetCurrentDirectory() + "\\Assets\\Images\\InGameImages"
            : Directory.GetCurrentDirectory() + "\\Assets\\Images\\ResultImages";
        PrincipalGalleryImageHandler(directorio);

        nextImg.onClick.AddListener(() => NextImgButton());
        prevImg.onClick.AddListener(() => PreviousImgButton());
        deleteImg.onClick.AddListener(() => DeleteCurrentImg());

        if (currentIdx == 0 && gallery.Count - 1 <= currentIdx)
        {
            prevImage.SetActive(false);
            nextImage.SetActive(false);
        }
        else if (currentIdx == 0)
        {
            prevImage.SetActive(false);
        }

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

            //Carga de imágenes iniciales
            if (gallery.Count > 0 )
            {
                currentImage.sprite = gallery[0];
                currentImageTxt.SetText(imageNames[0]);
            }
            
            if (gallery.Count > 1 )
            {
                nextImage.GetComponent<Image>().sprite = gallery[1];
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

    void NextImgButton()
    {
        if (currentIdx + 1 < gallery.Count)
        {
            currentIdx++;
        }

        if (gallery.Count > 0 )
        {
            currentImageTxt.SetText(imageNames[currentIdx]);
            currentImage.sprite = gallery[currentIdx];
        }
        ShowPreviousImg();
        ShowNextImg();
    }

    void PreviousImgButton()
    {
        if (currentIdx - 1 >= 0)
        {
            currentIdx--;
        }

        if (gallery.Count > 0 )
        {
            currentImageTxt.SetText(imageNames[currentIdx]);
            currentImage.sprite = gallery[currentIdx];
        }
        ShowPreviousImg();
        ShowNextImg();
    }

    void ShowPreviousImg()
    {
        if (currentIdx == 0)
        {
            imgBgPrev.SetActive(false);
            prevImage.SetActive(false);
            prevImg.enabled = false;
        }
        else
        {
            imgBgPrev.SetActive(true);
            prevImg.enabled = true;
            prevImage.SetActive(true);
            prevImage.GetComponent<Image>().sprite = gallery[currentIdx - 1];
        }
    }

    void ShowNextImg()
    {
        if (currentIdx >= gallery.Count - 1)
        {
            imgBgNext.SetActive(false);
            nextImg.enabled = false;
            nextImage.SetActive(false);
        }
        else
        {
            imgBgNext.SetActive(true);
            nextImg.enabled = true;
            nextImage.SetActive(true);
            nextImage.GetComponent<Image>().sprite = gallery[currentIdx + 1];
        }
    }

    void DeleteCurrentImg()
    {
        if (gallery.Count > 0 && gallery[currentIdx] != null)
        {
            if (pngGallery)
            {
                string currentMaskImageName = GetCurrentMaskImageName().Substring("result_".Length);
                File.Delete(Directory.GetCurrentDirectory() + "\\Python\\Masks\\" + currentMaskImageName);
            }

            imageNames.RemoveAt(currentIdx);
            gallery.RemoveAt(currentIdx);
            File.Delete(fullPathImageNames[currentIdx]);

            fullPathImageNames.RemoveAt(currentIdx);

            if (currentIdx + 1 < gallery.Count)
            {
                NextImgButton();
            }

            if (currentIdx - 1 >= 0)
            {
                PreviousImgButton();
            }
        }
    }

    public string GetCurrentImageName()
    {
        return imageNames[currentIdx];
    }

    public string GetCurrentMaskImageName()
    {
        return "mask"+imageNames[currentIdx];
    }
}