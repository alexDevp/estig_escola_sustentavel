using System.Collections;
using System.Collections.Generic;
using Database;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
    /**
     * Loads an image from a path into a rawImage game object
     */
    public void LoadImageFromPathIntoRawImage(string path, RawImage rawImage)
    {
        Texture2D myimage = Resources.Load<Texture2D>(path);
        Color currColor = rawImage.color;
        currColor.a = 1f;
        rawImage.color = currColor;
        rawImage.texture = myimage;
    }

    public void UnloadImage(RawImage rawImage)
    {
        Color currColor = rawImage.color;
        currColor.a = 0.15f;
        rawImage.color = currColor;
        rawImage.texture = null;
    }

}