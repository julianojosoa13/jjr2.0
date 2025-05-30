using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
   [SerializeField] private Button resumeButton;
   [SerializeField] private Button mainMenuButton;
   [SerializeField] private Transform playerOverviewTransform;

   private void Awake() {
      resumeButton.onClick.AddListener(()=> {
        playerOverviewTransform.gameObject.SetActive(false);
        gameObject.SetActive(false);
      });

       mainMenuButton.onClick.AddListener(()=> {
        Application.Quit();
      });
   }
}
