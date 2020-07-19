using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public BallBehaviour ballBehaviour;

    private void ResetPosition(Collider other)
    {
        if (other.CompareTag(ballBehaviour.tag))
        {
            ballBehaviour?.ResetPosition();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        ResetPosition(other);
    }
    private void OnTriggerEnter(Collider other)
    {
        ResetPosition(other);
    }
}
