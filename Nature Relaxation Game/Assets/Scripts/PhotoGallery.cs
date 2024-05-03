using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoGallery : MonoBehaviour
{
    public RawImage photoDisplay;
    public string[] filePaths;
    public int currentIndex = 0;

    public void Update()
    {
        LoadPhotos();
        ShowPhoto(currentIndex);
    }

    public void LoadPhotos()
    {
        string folderPath = Application.dataPath + "/Screenshots/";
        filePaths = Directory.GetFiles(folderPath, "*.png");
    }

    public void ShowPhoto(int index)
    {
        if (filePaths != null && index >= 0 && index < filePaths.Length)
        {
            byte[] fileData = File.ReadAllBytes(filePaths[index]);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            photoDisplay.texture = texture;
            photoDisplay.GetComponent<RawImage>().color = new Color(255,255,255,100);
        }
        else
        {
            photoDisplay.GetComponent<RawImage>().color = new Color(255, 255, 255, 0);
        }    
    }

    public void ShowNextPhoto()
    {
        if (filePaths != null && currentIndex < filePaths.Length - 1)
        {
            currentIndex++;
            ShowPhoto(currentIndex);
        }
    }

    public void ShowPreviousPhoto()
    {
        if (filePaths != null && currentIndex > 0)
        {
            currentIndex--;
            ShowPhoto(currentIndex);
        }
    }
}
