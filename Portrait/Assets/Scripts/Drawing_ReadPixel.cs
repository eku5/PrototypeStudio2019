using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing_ReadPixel : MonoBehaviour
{
    // Grab the camera's view when this variable is true.
    bool grab;

    public GameObject buttonToHide;

    // The "m_Display" is the GameObject whose Texture will be set to the captured image.
    public Renderer m_Display;

    private void Update()
    {
       
    }
    
    
    private int currentView = 0;
    public float xAdjust = 0f;
    public float yAdjust = 0f;
    public Transform[] viewPositions;
    public Renderer pageRenderer;
    private void OnPostRender()
    {
        //Debug.Log("PostRender did a thing");
        if (grab)
        {
            //Create a new texture with the width and height of the screen
            //Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

            Vector2 topRight = Camera.main.WorldToScreenPoint(pageRenderer.bounds.max);
            Vector2 botLeft = Camera.main.WorldToScreenPoint(pageRenderer.bounds.min);
            int paperWidth = (int)topRight.x - (int)botLeft.x;
            int paperHeight = (int)topRight.y - (int)botLeft.y;
            Debug.Log(topRight + " " + botLeft);
            Texture2D texture = new Texture2D(paperWidth, paperHeight, TextureFormat.RGB24, false);
            //Read the pixels in the Rect starting at 0,0 and ending at the screen's width and height
            //texture.ReadPixels(new Rect(xAdjust, yAdjust, Screen.width - xAdjust, Screen.height - yAdjust), 0, 0, false);
            texture.ReadPixels(new Rect(botLeft.x, botLeft.y, paperWidth, paperHeight), 0, 0, false);
            texture.Apply();
            //Check that the display field has been assigned in the Inspector
            if (m_Display != null)
                //Give your GameObject with the renderer this texture
                m_Display.material.mainTexture = texture;
            //Reset the grab state
            grab = false;
            Camera.main.transform.position = viewPositions[currentView].position;
            currentView++;
            Debug.Log("grab function worked?");
        }
        
    }

    public void grabCheck()
    {
        StartCoroutine(HideButton());
    }

    IEnumerator HideButton()
    {
        buttonToHide.SetActive(false);
        yield return null;
        grab = true;
        yield return null;
        buttonToHide.SetActive(true);
    }

}
