using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private List<TimelineFactSO> timelineFactSOList;
    [SerializeField] private DiscoveredTemplate discoveredTemplate;
    [SerializeField] private EmptyTemplate emptyTemplate;
    [SerializeField] private Button backButton;
    [SerializeField] private Transform contentContainerTransform;

    private void Awake()
    {
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
        int index = 1;

        foreach (TimelineFactSO factSO in timelineFactSOList)
        {
            Transform discoveredFactTransform = Instantiate(discoveredTemplate.transform);
            discoveredFactTransform.TryGetComponent<DiscoveredTemplate>(out DiscoveredTemplate discoveredFact);
            discoveredFact.SetNumber(index);
            discoveredFact.SetTimelineFactSO(factSO);
            discoveredFactTransform.SetParent(contentContainerTransform);
            discoveredFactTransform.gameObject.SetActive(true);
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
    }

    // private void ClearList()
    // {
    //     timelineFactSOList.Clear();
    // }

    public void Show()
    {
        UpdateList();
        gameObject.SetActive(true);
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
