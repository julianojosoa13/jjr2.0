public class TimelineFactStorage : MonoBehaviour
{
    // Save a list of TimelineFactSO to PlayerPrefs
    public static void SaveFacts(List<TimelineFactSO> facts)
    {
        TimelineFactListWrapper wrapper = new TimelineFactListWrapper();
        
        foreach (var fact in facts)
        {
            wrapper.facts.Add(new TimelineFactData(fact));
        }
        
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("SavedTimelineFacts", json);
        PlayerPrefs.Save();
        Debug.Log("Facts saved: " + json);
    }

    // Load a list of TimelineFactSO from PlayerPrefs
    public static List<TimelineFactSO> LoadFacts()
    {
        List<TimelineFactSO> loadedFacts = new List<TimelineFactSO>();
        
        if (PlayerPrefs.HasKey("SavedTimelineFacts"))
        {
            string json = PlayerPrefs.GetString("SavedTimelineFacts");
            TimelineFactListWrapper wrapper = JsonUtility.FromJson<TimelineFactListWrapper>(json);
            
            foreach (var factData in wrapper.facts)
            {
                TimelineFactSO fact = ScriptableObject.CreateInstance<TimelineFactSO>();
                factData.ApplyTo(fact);
                loadedFacts.Add(fact);
            }
        }
        
        return loadedFacts;
    }

    // Clear saved facts
    public static void ClearSavedFacts()
    {
        PlayerPrefs.DeleteKey("SavedTimelineFacts");
        PlayerPrefs.Save();
    }
}