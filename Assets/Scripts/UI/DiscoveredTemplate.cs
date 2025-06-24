using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveredTemplate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI dateText;

    private TimelineFactSO timelineFactSO;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            if (timelineFactSO != null)
            {
                Debug.Log(timelineFactSO.headline);
            }
        });
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
