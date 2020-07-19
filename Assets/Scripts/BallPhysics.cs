using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private bool ballHit = false;

    public float movementFactor = 1;
    public delegate void BallState();
    public event BallState OnBallHit;
    public event BallState OnBallLeft;
    public float maxSpeed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private Vector3 ClampVector(Vector3 vector, float limit)
    {
        limit = Mathf.Abs(limit);
        var tmp = new Vector3(Mathf.Clamp(vector.x, -limit, limit), Mathf.Clamp(vector.y, -limit, limit), Mathf.Clamp(vector.z, -limit, limit));
        return tmp;
    }
    /// <summary>
    /// Gives the ball movement when it is hit by Racket
    /// </summary>
    /// <param name="other"></param>
    private void HandleCollision(Collider other)
    {
        if (other.CompareTag("Racket"))
        {
            var racket = other.GetComponent<RacketMovement>();

            // first touch
            if (!ballHit)
            {
                ballHit = true;
                // stops the ball
                rb.velocity = Vector3.zero;
                var force = ClampVector((racket.Movement) * movementFactor, maxSpeed);
                Debug.Log("Force: " + force);
                rb.AddForce(force);
                OnBallHit?.Invoke();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Racket"))
        {
            ballHit = false;
            OnBallLeft?.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        HandleCollision(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }
}
