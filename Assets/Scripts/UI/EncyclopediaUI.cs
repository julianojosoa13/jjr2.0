using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaUI : MonoBehaviour
{
    public static EncyclopediaUI Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private List<TimelineFactSO> timelineFactSOList;
    [SerializeField] private DiscoveredTemplate discoveredTemplate;
    [SerializeField] private EmptyTemplate emptyTemplate;
    [SerializeField] private Button backButton;
    [SerializeField] private Transform contentContainerTransform;
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] private Image progressUI;
    [SerializeField] private TextMeshProUGUI percentageText;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI headlineText;
    [SerializeField] private TextMeshProUGUI factText;
    [SerializeField] private Transform factViewer;

    private TimelineFactSO selectedFactSO;


    private void Awake()
    {
        Instance = this;
        timelineFactSOList = new List<TimelineFactSO>();
    }
    void Start()
    {


        backButton.onClick.AddListener(() =>
        {
            Hide();
        });

        Hide();
    }

    private void UpdateList()
    {
        timelineFactSOList = GameManager.Instance.GetKnowFacts();

        if (timelineFactSOList.Count == 0)
        {
            factViewer.gameObject.SetActive(false);
        }
        else
        {
            factViewer.gameObject.SetActive(false);
        }

        int index = 1;

        foreach (TimelineFactSO factSO in timelineFactSOList)
        {
            Transform discoveredFactTransform = Instantiate(discoveredTemplate.transform);
            discoveredFactTransform.TryGetComponent<DiscoveredTemplate>(out DiscoveredTemplate discoveredFact);
            discoveredFact.SetNumber(index);
            discoveredFact.SetTimelineFactSO(factSO);
            discoveredFactTransform.SetParent(contentContainerTransform);
            discoveredFactTransform.gameObject.SetActive(true);
            if (index == 1)
            {
                discoveredFact.SelectSelf();
            }
            index++;
        }
        int undiscovered = 21 - index;
        for (int i = 0; i < undiscovered; i++)
        {
            Transform emptyFactTransform = Instantiate(emptyTemplate.transform);
            emptyFactTransform.TryGetComponent<EmptyTemplate>(out EmptyTemplate emptyFact);
            emptyFact.SetNumber(index);
            emptyFactTransform.gameObject.SetActive(true);
            emptyFactTransform.SetParent(contentContainerTransform);
            index++;
        }

        progressUI.fillAmount = (float)timelineFactSOList.Count / 20;
        percentageText.text = MathF.Floor(timelineFactSOList.Count * 5f) + "%";

    }

    // private void ClearList()
    // {
    //     timelineFactSOList.Clear();
    // }

    public void Show()
    {
        UpdateList();
        scrollView.verticalNormalizedPosition = 1f;
        gameObject.SetActive(true);
    }

    public void SetSelectedFact(TimelineFactSO factSO)
    {
        this.selectedFactSO = factSO;

        dateText.text = selectedFactSO.date;
        headlineText.text = selectedFactSO.headline;
        factText.text = selectedFactSO.fact;
        factViewer.gameObject.SetActive(true);
    }

    public void Hide()
    {
        // ClearList();

        foreach (Transform children in contentContainerTransform)
        {
            if (children.gameObject.activeInHierarchy)
            {
                Destroy(children.gameObject);
            }
        }
        gameObject.SetActive(false);
    }
}
