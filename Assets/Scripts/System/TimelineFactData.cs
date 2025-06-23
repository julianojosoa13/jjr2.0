using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimelineFactData
{
    public string date;
    public string fact;
    public string headline;
    public string number;

    public TimelineFactData(TimelineFactSO so)
    {
        this.date = so.date;
        this.fact = so.fact;
        this.headline = so.headline;
        this.number = so.number;
    }

    public void ApplyTo(TimelineFactSO so)
    {
        so.date = this.date;
        so.fact = this.fact;
        so.headline = this.headline;
        so.number = this.number;
    }
}

[System.Serializable]
public class TimelineFactListWrapper
{
    public List<TimelineFactData> facts = new List<TimelineFactData>();
}