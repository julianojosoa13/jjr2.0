using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;

    private int frameCount;
    private float elapsedTime;
    private float refreshRate = 1f;

    // private void Start()
    // {
    //     fpsText = GetComponent<TextMeshProUGUI>();
    // }

    void Update()
    {
        frameCount++;
        elapsedTime += Time.unscaledDeltaTime;

        if (elapsedTime >= refreshRate)
        {
            int fps = Mathf.RoundToInt(frameCount / elapsedTime);
            fpsText.text = $"FPS: {fps}";
            frameCount = 0;
            elapsedTime = 0f;
        }
    }
}
