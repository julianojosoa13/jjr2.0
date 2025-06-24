using System;
using UnityEngine;
using UnityEngine.UI;

public class BookCollectible : Interactable
{
   [SerializeField] private Canvas canvas;
   [SerializeField] private TimelineFactSO fact;

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

   public override void Interact()
   {
      FactsUI.Instance.SetTimelineFact(fact);
      FactsUI.Instance.Show();
      if (!GameManager.Instance.AlreadyDiscovered(fact))
      {
         Debug.Log(GameManager.Instance.GetKnowFacts().Count);
         GameManager.Instance.AddKnowFact(fact);
         Debug.Log(GameManager.Instance.GetKnowFacts().Count);
         // Debug.Log("Found " + GameManager.Instance.GetKnowFacts().Count + " / 20");
         FactsUI.Instance.ShowSuccessMessage(GameManager.Instance.GetKnowFacts().Count);
      }
   }

   public override void ActivateVisual()
   {
      canvas.GetComponent<CanvasGroup>().alpha = 1f;
   }

   public override void DeactivateVisual()
   {
      canvas.GetComponent<CanvasGroup>().alpha = 0.25f;
   }
}
