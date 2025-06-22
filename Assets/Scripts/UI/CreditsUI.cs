using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private ScrollRect scrollRect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            scrollRect.verticalNormalizedPosition = 1f;
        });

        // gameObject.SetActive(false);
    }
}
