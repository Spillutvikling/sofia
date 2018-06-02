using UnityEngine;
using System.Collections;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public float updateInterval = 0.5F;
    public TextMeshProUGUI fpsText;
    public bool show;

    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval

    void Start()
    {
        if (!show)
        {
            fpsText.enabled = false;
            enabled = false;
            return;
        }

        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            float fps = accum / frames;
            string format = System.String.Format("FPS: {0:F0}", fps);
            fpsText.text = format;

            if (fps < 30)
                fpsText.color = Color.yellow;
            else
                if (fps < 10)
                fpsText.color = Color.red;
            else
                fpsText.color = Color.green;

            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }
}