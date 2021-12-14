using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinSample : MonoBehaviour
{
    // Width and height of the texture in pixels.
    public int pixWidth =256;
    public int pixHeight =256;



    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 20.0F;

    private Texture2D noiseTex;
    private Color[] pix;
    private SpriteRenderer rend;

    void Start()
    {
        //Random.InitState(4815162342);
        Debug.Log("Perlin!!!");
        rend = GetComponent<SpriteRenderer>();
        Debug.Log(rend);
        //Debug.Log()

        // Set up the texture and a Color array to hold pixels during processing.
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.sprite = Sprite.Create(GenerateTexture(), new Rect(0, 0, pixWidth, pixHeight), new Vector2(0.5f, 0.5f));
       // rend.material.mainTexture= GenerateTexture();
        //rend.color = new Color(44/255f, 44/255f, 44/255f);

    }



    private Texture2D GenerateTexture()
    {
       
        Texture2D texture = new Texture2D(pixWidth, pixHeight);

        for(int x =0; x< pixWidth; x++)
        {
            for(int y =0; y<pixHeight; y++)
            {
                //Debug.Log("Texture!!");
                Color colour = CalculateColour(x, y);
                texture.SetPixel(x, y, colour);
            }
        }
        texture.Apply();
        return texture;
    }

    private Color CalculateColour(int x, int y)
    {
        float xPerlin = (float)x / pixWidth *20f;
        float yPerlin = (float)y / pixHeight *20f;
        float perlin= Mathf.PerlinNoise(xPerlin, yPerlin);
        return new Color(perlin, perlin, perlin);
    }

    void Update()
    {
        
    }
}
