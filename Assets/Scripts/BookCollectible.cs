using System;
using UnityEngine;
using UnityEngine.UI;

public class BookCollectible : Interactable
{
   [SerializeField] private Canvas canvas;
   
   // private void Start() {
   //    Player.Instance.OnInteractableDetected += Player_OnInteractableDetected;
   //    Player.Instance.OnInteractableOutOfRange += Player_OnInteractableOutOfRange;
   // }

   // private void Player_OnInteractableDetected(object sender, EventArgs e) {
   //    ActivateVisual();
   // }

   // private void Player_OnInteractableOutOfRange(object sender, EventArgs e) {
   //    DeactivateVisual();
   // }
   
   public override void Interact() {
    Debug.Log("Interact!");
   }

   public override void ActivateVisual() {
      canvas.GetComponent<CanvasGroup>().alpha = 1f;
   }

   public override void DeactivateVisual() {
      canvas.GetComponent<CanvasGroup>().alpha = 0.25f;
   }
}
