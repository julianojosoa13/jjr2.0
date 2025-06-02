using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
   [SerializeField] private Button pauseButton;
   [SerializeField] private Transform pauseUITransform;
   [SerializeField] private Transform playerOverviewTransform;

   [SerializeField] private Button actionButton;
   [SerializeField] private Button cameraButton;

   [SerializeField] private Transform cameraPivotTransform;

   private float currentBias = 0f;


   private void Awake()
   {
      pauseButton.onClick.AddListener(() =>
      {
         playerOverviewTransform.gameObject.SetActive(true);
         pauseUITransform.gameObject.SetActive(true);
      });

      cameraButton.onClick.AddListener(() =>
      {
         _ = RotateYBy90Async(cameraPivotTransform, 0.3f);
      });
   }

   private async Task RotateYBy90Async(Transform target, float duration)
   {
      Quaternion startRotation = target.rotation;
      Quaternion endRotation = startRotation * Quaternion.Euler(0f, 90f, 0f);

      float elapsed = 0f;

      while (elapsed < duration)
      {
         await Task.Yield(); // Wait for the next frame
         elapsed += Time.deltaTime;
         float t = Mathf.Clamp01(elapsed / duration);
         target.rotation = Quaternion.Slerp(startRotation, endRotation, t);
      }

      target.rotation = endRotation; // Snap to exact rotation at the end
   }
}
