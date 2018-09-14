using UnityEngine;

public class UnityTimeService : ITimerService
{
    public float Detatime()
    {
        return Time.deltaTime;
    }

    public float TimeScale
    {
        get { return Time.timeScale; }
        set { Time.timeScale = value; }
    }
}