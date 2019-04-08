using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePicture : MonoBehaviour
{
    private int screenshotCount = 0;
    
    // This one works in the Unity editor but not the build...
    public void SavePhoto()
    {
        ScreenCapture.CaptureScreenshot("SafePlace_" + screenshotCount + ".png");
        Debug.Log("SavePhoto called.");
        screenshotCount++;
    }
    
    public void callCapture()
    {
        String imagePath = Application.persistentDataPath + "/image.png";
        StartCoroutine(captureScreenshot());
        screenshotCount++;
    }

    
    IEnumerator captureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        string path = Application.persistentDataPath + "Screenshots/"
                                                     + "_" + screenshotCount + "_" + Screen.width + "X" + Screen.height + "" + ".jpg";

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        //Convert to JPG
        byte[] imageBytes = screenImage.EncodeToJPG(); //using EncodeToJPG instead of EncodeToPNG because of file size

        //Save image to file
        System.IO.File.WriteAllBytes(path, imageBytes);
    }
    
}
