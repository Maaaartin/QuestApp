using UnityEngine;

/// <summary>
/// Slows down time when ball this the collider 
/// </summary>
public class ArenaCollision : MonoBehaviour
{
    public TimeManager timeManager;
    public BallPhysics ballPhysics;
    private bool ballHit = false;

    void Start()
    {
        ballPhysics.OnBallHit += BallPhysics_OnBallHit;
    }

    private void BallPhysics_OnBallHit()
    {
        ballHit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (ballPhysics.CompareTag(other.tag))
        {
            timeManager.UndoSlowmotion();
            ballHit = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (ballPhysics.CompareTag(other.tag))
        {
            if (!ballHit)
            {
                timeManager.DoSlowmotion();
            }
            else
            {
                timeManager.UndoSlowmotion();
            }
        }
    }
}
