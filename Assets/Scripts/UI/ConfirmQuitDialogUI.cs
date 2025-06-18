using UnityEngine;
using UnityEngine.UI;

public class ConfirmQuitDialogUI : MonoBehaviour
{
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noButton.onClick.AddListener(()=>{
            gameObject.SetActive(false);
        });

        yesButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }
}
