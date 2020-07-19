using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    // Update is called once per frame
    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void UndoSlowmotion()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
