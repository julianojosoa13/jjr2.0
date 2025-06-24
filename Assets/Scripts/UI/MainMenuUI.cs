using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
  [SerializeField] private Button playButton;
  [SerializeField] private Button credtisButton;
  [SerializeField] private Button quitButton;
  [SerializeField] private Button settingsButton;
  [SerializeField] private Button achivementsButton;
  [SerializeField] private RectTransform confirmQuitDialogRectTransform;
  [SerializeField] private RectTransform creditsUIRectTransform;
  [SerializeField] private RectTransform settingsUIRectTransform;
  [SerializeField] private EncyclopediaUI encyclopediaUI;

  private void Start()
  {
    confirmQuitDialogRectTransform.gameObject.SetActive(false);
    playButton.onClick.AddListener(() =>
    {
      Loader.Load(Loader.Scene.Analakely);
    });

    quitButton.onClick.AddListener(() =>
    {
      confirmQuitDialogRectTransform.gameObject.SetActive(true);
    });

    credtisButton.onClick.AddListener(() =>
    {
      creditsUIRectTransform.gameObject.SetActive(true);
    });

    settingsButton.onClick.AddListener(() =>
    {
      settingsUIRectTransform.gameObject.SetActive(true);
    });

    achivementsButton.onClick.AddListener(() =>
    {
      encyclopediaUI.Show();
    });
  }
}
