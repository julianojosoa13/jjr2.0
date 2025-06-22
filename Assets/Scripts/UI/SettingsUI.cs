using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private ScrollRect scrollRect;
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            scrollRect.verticalNormalizedPosition = 1f;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
