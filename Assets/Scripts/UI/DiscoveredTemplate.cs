using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveredTemplate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private Button button;

    private TimelineFactSO timelineFactSO;
    // private void Awake()
    // {
    //     button = GetComponent<Button>();
    // }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            SelectSelf();
        });
    }

    public void SelectSelf()
    {
        if (timelineFactSO != null)
        {
            button.Select();
            EncyclopediaUI.Instance.SetSelectedFact(timelineFactSO);
        }

    }

    public void SetNumber(int number)
    {
        numberText.text = number.ToString();
    }

    public void SetTimelineFactSO(TimelineFactSO timelineFactSO)
    {
        this.timelineFactSO = timelineFactSO;
        dateText.text = timelineFactSO.date;
    }
}
