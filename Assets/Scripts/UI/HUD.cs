using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
   [SerializeField] private Button pauseButton;
   [SerializeField] private Transform pauseUITransform;
   [SerializeField] private Transform playerOverviewTransform;

   private void Awake() {
      pauseButton.onClick.AddListener(()=> {
        playerOverviewTransform.gameObject.SetActive(true);
        pauseUITransform.gameObject.SetActive(true);
      });
   }
}
