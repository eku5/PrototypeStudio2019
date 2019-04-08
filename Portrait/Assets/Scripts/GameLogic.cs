using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int currentView = 0;
    public Transform[] viewPositions;

    public Texture2D savedTexture;
    public Material savedTextureMaterial;
    public void TakeScreenshot()
    {
        savedTexture = ScreenCapture.CaptureScreenshotAsTexture();
        savedTextureMaterial.mainTexture = savedTexture;
        

        Camera.main.transform.position = viewPositions[currentView].position;
        currentView++;

    }
}
