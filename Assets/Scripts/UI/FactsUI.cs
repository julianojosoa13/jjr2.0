using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactsUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI headelineText;
    [SerializeField] private RectTransform successMessageUI;
    [SerializeField] private TextMeshProUGUI successNumberText;
    [SerializeField] private AudioClip closeSound;

    public static FactsUI Instance { get; private set; }
    private TimelineFactSO fact;
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            AudioSource.PlayClipAtPoint(closeSound, Camera.main.transform.position, 0.3f);
            Hide();
        });

        Hide();
    }

    public void ShowSuccessMessage(int number)
    {
        successNumberText.text = "" + number + " / 20";
        successMessageUI.gameObject.SetActive(true);
        audioSource.Play();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        successMessageUI.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        successMessageUI.gameObject.SetActive(false);
    }

    public void SetTimelineFact(TimelineFactSO factSO)
    {
        this.fact = factSO;
        dateText.text = this.fact.date;
        descriptionText.text = this.fact.fact;
        numberText.text = this.fact.number;
        headelineText.text = this.fact.headline;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
