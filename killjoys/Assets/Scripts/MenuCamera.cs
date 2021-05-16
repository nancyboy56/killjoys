using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 5.0F;

    public Camera cam;

    private float hueShiftSpeed = 0.02f;
    private float saturation = 0.8f;
    private float value = 0.9f;

    void Start()
    {
        cam = GetComponent<Camera>();
       // cam
        cam.clearFlags = CameraClearFlags.SolidColor;
        Debug.Log("colours");
    }

    /* void Update()
     {
         float t = Mathf.PingPong(Time.time, duration) / duration;
         cam.backgroundColor = Color.Lerp(color1, color2, t);

         Debug.Log("wow122");
     }*/

    private void Update()
    {
        float amountToShift = hueShiftSpeed * Time.deltaTime;
        Color newColor = ShiftHueBy(cam.backgroundColor, amountToShift);
        cam.backgroundColor = newColor;
    }

    private Color ShiftHueBy(Color color, float amount)
    {
        // convert from RGB to HSV
        Color.RGBToHSV(color, out float hue, out float sat, out float val);

        // shift hue by amount
        hue += amount;
        sat = saturation;
        val = value;

        // convert back to RGB and return the color
        return Color.HSVToRGB(hue, sat, val);
    }


}
