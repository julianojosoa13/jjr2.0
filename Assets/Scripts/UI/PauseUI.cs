using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
   [SerializeField] private Button resumeButton;
   [SerializeField] private Button mainMenuButton;
   [SerializeField] private Transform playerOverviewTransform;
   [SerializeField] AudioClip closeSound;

   private AudioSource audioSource;

   private void Awake()
   {
      audioSource = GetComponent<AudioSource>();
   }

   private void Start()
   {
      resumeButton.onClick.AddListener(() =>
      {
         playerOverviewTransform.gameObject.SetActive(false);
         gameObject.SetActive(false);
         AudioSource.PlayClipAtPoint(closeSound, Camera.main.transform.position, 0.3f);
      });

      mainMenuButton.onClick.AddListener(() =>
      {
         //   Application.Quit();
         Loader.Load(Loader.Scene.MainMenu);
      });
   }
}
