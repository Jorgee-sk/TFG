using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TiledMapCustom : Tile
{
    public CustomImages customImages;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        string directorioOriginal = Application.dataPath + "\\Images\\TiledMaps";
        string directorio = Application.dataPath + "\\Images\\ResultImages";
        string directorioInGame = Application.dataPath + "\\Images\\InGameImages";

        if (customImages.enemyImageToSet == null || customImages.enemyImageToSet.Equals(""))
        {
            if (Directory.Exists(directorioOriginal))
            {
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioOriginal);

                FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");

                foreach (FileInfo archivoPNG in archivosPNG)
                {
                    if (archivoPNG.Name.Equals("tiledWall.png"))
                    {
                        byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
                        Texture2D loadTexture = new Texture2D(1, 1);
                        loadTexture.LoadImage(bytes);

                        Sprite currentSprite = Sprite.Create(loadTexture,
                            new Rect(0, 0, loadTexture.width, loadTexture.height),
                            new Vector2(0.5f, 0.5f));


                        tileData.sprite = currentSprite;
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

                        tileData.sprite = currentSprite;
                        break;
                    }
                }
            }
            //else if (Directory.Exists(directorioInGame))
            //{
            //    DirectoryInfo directorioInfo = new DirectoryInfo(directorioInGame);
//
            //    FileInfo[] archivosPNG = directorioInfo.GetFiles("*.png");
//
            //    foreach (FileInfo archivoPNG in archivosPNG)
            //    {
            //        if (archivoPNG.Name.Equals(customImages.enemyImageToSet))
            //        {
            //            byte[] bytes = File.ReadAllBytes(archivoPNG.FullName);
            //            Texture2D loadTexture = new Texture2D(1, 1);
            //            loadTexture.LoadImage(bytes);
//
            //            Sprite currentSprite = Sprite.Create(loadTexture,
            //                new Rect(0, 0, loadTexture.width, loadTexture.height),
            //                new Vector2(0.5f, 0.5f));
//
            //            tileData.sprite = currentSprite;
            //            break;
            //        }
            //    }
            //}
            else
            {
                Debug.LogError("El directorio no existe: " + directorio);
            }
        }
    }

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        tilemap.RefreshTile(position);
    }
}