using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    private List<TimelineFactSO> discoveredFacts;

    private void Awake()
    {
        Instance = this;
        TimelineFactStorage.ClearSavedFacts();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        discoveredFacts = TimelineFactStorage.LoadFacts();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public List<TimelineFactSO> GetKnowFacts()
    {
        return discoveredFacts;
    }
    public void AddKnowFact(TimelineFactSO timelineFactSO)
    {
        discoveredFacts.Add(timelineFactSO);
        TimelineFactStorage.SaveFacts(discoveredFacts);
    }

    public bool AlreadyDiscovered(TimelineFactSO timelineFactSO)
    {
        foreach (var fact in discoveredFacts)
        {
            if (timelineFactSO.headline == fact.headline)
            {
                return true;
            }
        }
        return false;
    }
}
