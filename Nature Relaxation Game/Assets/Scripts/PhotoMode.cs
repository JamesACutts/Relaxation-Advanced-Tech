using UnityEngine;

public class PhotoMode : MonoBehaviour
{
    private bool isPhotoModeActive = false;
    public GameObject gallery;
    void Update()
    {
        // Toggle Photo Mode when the right mouse button is held down
        if (Input.GetMouseButtonDown(1) && !gallery.activeSelf)
        {
            isPhotoModeActive = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isPhotoModeActive = false;
        }

        // Take a screenshot when the left mouse button is clicked in Photo Mode
        if (isPhotoModeActive && Input.GetMouseButtonDown(0))
        {
            TakeScreenshot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gallery.SetActive(!gallery.activeSelf);
            if (gallery.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void TakeScreenshot()
    {
        // Define the folder path for saving screenshots
        string folderPath = Application.dataPath + "/Screenshots/";

        // Ensure that the folder exists; if not, create it
        if (!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        // Define the screenshot file name with the current date and time
        string screenshotName = "screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";

        // Combine the folder path and screenshot name to get the full file path
        string filePath = System.IO.Path.Combine(folderPath, screenshotName);

        // Capture a screenshot of the game view and save it to the specified file path
        ScreenCapture.CaptureScreenshot(filePath);

        // Force Unity to flush any pending file operations to ensure the screenshot is saved immediately
        System.IO.File.WriteAllText(filePath, string.Empty);

        // Log the file path to indicate where the screenshot is saved
        Debug.Log("Screenshot captured: " + filePath);
    }
}
