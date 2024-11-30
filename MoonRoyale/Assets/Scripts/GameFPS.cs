using TMPro;
using UnityEngine;

public class GameFPS : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsText;
    float fps;
    float updateTimer = 0.25f;

    void Start()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value; // limits frame rate to monitor refresh rate
    }

    // Update is called once per frame
    void Update()
    {
        updateFpsCounter(); // updates fps counter every frame
    }

    private void updateFpsCounter()
    {
        updateTimer -= Time.deltaTime; // take away time since last frame
        if (updateTimer <= 0f)
        {
            fps = 1f / Time.unscaledDeltaTime;
            fpsText.text = "FPS: " + Mathf.Round(fps);
            updateTimer = 0.2f;
        }
    }
}