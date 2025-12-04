using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public Renderer targetRenderer; //object's renderer component
    public Color glowColor = Color.green; //glow color
    private float pulseSpeed = 2f; //speed of which the color pulses
    public float maxIntensity = 0.05f; //the max brightness

    private Material mat;

    void Start()
    {
        mat = targetRenderer.material; //copy of object's material
        mat.EnableKeyword("_EMISSION"); //enable emission properly
    }

    void Update()
    {
        //emission value will rise a fall between 0 and the max brightness for a smooth glowing loop
        float emission = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f * maxIntensity; //creates a sin wave of -1 and 1 with a range of 0-2 and scaled down to 0-1 then multiples by max brightness of the glow
        Color finalColor = glowColor * Mathf.LinearToGammaSpace(emission); // multiples glow color with brightness
        mat.SetColor("_EmissionColor", finalColor); //updates object's emissionColor property in real time
    }
}


