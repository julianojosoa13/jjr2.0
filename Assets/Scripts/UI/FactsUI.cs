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


    public static FactsUI Instance { get; private set; }
    private TimelineFactSO fact;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });

        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
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
