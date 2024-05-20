using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace OpenAI
{
    public class DallE : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Image resultImage;
        [SerializeField] private Button button;
        [SerializeField] private GameObject loadGameObject;
        [SerializeField] private Sprite sprite;
        
        private DallEServiceImpl _dallEServiceImpl;

        private void Start()
        {
            GameObject newGameObject = new GameObject("NuevoObjeto");
            _dallEServiceImpl = newGameObject.AddComponent<DallEServiceImpl>();
            button.onClick.AddListener(GetAnImageByPrompt);
        }

        /**
         * Llamada asociada al botón de la pantalla que realiza la petición
         */
        private async void GetAnImageByPrompt()
        {
            resultImage.sprite = sprite;
            loadGameObject.SetActive(true);

            var dallEResponse = await _dallEServiceImpl.GetImage(new DallERequestDTO
            {
                Model = "dall-e-3",
                Prompt = inputField.text,
                Size = SizeImage.SizeImage1024X1024
            });

            if (!dallEResponse.Data.Equals(null) && dallEResponse.Data.Count > 0)
            {
                using var request = new UnityWebRequest(dallEResponse.Data[0].Url);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                request.SendWebRequest();

                do
                {
                    await Task.Yield();
                } while (!request.isDone);

                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(request.downloadHandler.data);
                Save(texture);
                var sprite = Sprite.Create(texture, new Rect(0, 0, 1024, 1024), Vector2.zero, 1f);
                resultImage.sprite = sprite;
            }
            else
            {
                Debug.LogError("NO IMAGE WAS CREATED FOR THIS PROMPT");
            }

            loadGameObject.SetActive(false);
        }

        /*
         * Class to set the different images size
         */
        private static class SizeImage
        {
            public const string SizeImage256X256 = "256x256";
            public const string SizeImage512X512 = "512x512";
            public const string SizeImage1024X1024 = "1024x1024";
        }

        public void Save(Texture2D texture2D)
        {
            byte[] bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(
                Directory.GetCurrentDirectory() + "/Assets/Images/InGameImages/" +
                Regex.Replace(inputField.text, @"\s", "") + "_Image.png", bytes);
        }
    }
}