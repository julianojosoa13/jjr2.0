using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
   public static HUD Instance {get; private set;}
   public event EventHandler OnActionButtonPressed; 

   [SerializeField] private Button pauseButton;
   [SerializeField] private Button actionButton;
   [SerializeField] private Transform pauseUITransform;
   [SerializeField] private Transform playerOverviewTransform;
   [SerializeField] private Transform actionButtonBackground;


   private void Awake() {
      Instance = this;

      pauseButton.onClick.AddListener(()=> {
        playerOverviewTransform.gameObject.SetActive(true);
        pauseUITransform.gameObject.SetActive(true);
      });

      actionButton.onClick.AddListener(() => {
         OnActionButtonPressed?.Invoke(this, EventArgs.Empty);
      });
   }

   private void Start() {
      Player.Instance.OnInteractableDetected += Player_OnInteractableDetected;
      Player.Instance.OnInteractableOutOfRange += Player_OnInteractableOutOfRange;
   }

   private void Player_OnInteractableDetected(object sender, EventArgs e) {
      actionButtonBackground.gameObject.SetActive(true);
   }

   private void Player_OnInteractableOutOfRange(object sender, EventArgs e) {
      actionButtonBackground.gameObject.SetActive(false);
   }
}
