using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeleteButton : MonoBehaviour
{
    public PhotoGallery photoGallery;

    public void DeleteCurrentPhoto()
    {
        if (photoGallery != null && photoGallery.filePaths != null && photoGallery.currentIndex >= 0 && photoGallery.currentIndex < photoGallery.filePaths.Length)
        {
            string filePath = photoGallery.filePaths[photoGallery.currentIndex];

            // Delete the file from the file system
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("Deleted photo: " + filePath);
            }
            else
            {
                Debug.LogWarning("File does not exist: " + filePath);
            }

            // Reload the photos and display the next photo
            photoGallery.LoadPhotos();
            if (photoGallery.filePaths.Length > 0)
            {
                photoGallery.currentIndex = Mathf.Clamp(photoGallery.currentIndex, 0, photoGallery.filePaths.Length - 1);
                photoGallery.ShowPhoto(photoGallery.currentIndex);
            }
            else
            {
                photoGallery.photoDisplay.texture = null;
            }
        }
    }
}
