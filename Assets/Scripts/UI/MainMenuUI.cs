using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
   [SerializeField] private Button playButton;
   [SerializeField] private Button credtisButton;
   [SerializeField] private Button quitButton;
   [SerializeField] private RectTransform confirmQuitDialogRectTransform;

   private void Start() {
      confirmQuitDialogRectTransform.gameObject.SetActive(false);
      playButton.onClick.AddListener(() => {
        Loader.Load(Loader.Scene.Analakely);
      });

      quitButton.onClick.AddListener(()=> {
        confirmQuitDialogRectTransform.gameObject.SetActive(true);
      });
   }
}
