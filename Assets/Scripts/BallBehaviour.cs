using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{
    private Vector3 initPostition;
    private BallPhysics physics;
    private Rigidbody rb;
    private bool keepPostition = true;
    private Pose pose;
    void Start()
    {
        physics = GetComponent<BallPhysics>();
        rb = GetComponent<Rigidbody>();
        pose = GetComponent<Pose>();

        pose.OnObjectPosed += Pose_OnObjectPosed;
        physics.OnBallHit += Physics_OnBallHit;
    }

    private void Physics_OnBallHit()
    {
        keepPostition = false;
    }

    private void Pose_OnObjectPosed(Vector3 position)
    {
        initPostition = position;
    }

    /// <summary>
    /// Places the ball to initial postition
    /// </summary>
    public void ResetPosition()
    {
        transform.position = initPostition;
        keepPostition = true;
        rb.velocity = Vector3.zero;
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.A))
            {
                initPostition += Vector3.left / 100;
            }
            if (Input.GetKey(KeyCode.D))
            {
                initPostition += Vector3.right / 100;
            }
            if (Input.GetKey(KeyCode.W))
            {
                initPostition += Vector3.forward / 100;
            }
            if (Input.GetKey(KeyCode.S))
            {
                initPostition += Vector3.back / 100;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                initPostition += Vector3.down / 100;
            }
            if (Input.GetKey(KeyCode.E))
            {
                initPostition += Vector3.up / 100;
            }
        }
        float x = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x, z = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
        float y = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (x != 0 || z != 0 || y != 0)
        {
            rb?.AddForce(Vector3.forward * z);
            rb?.AddForce(Vector3.right * x);
            rb?.AddForce(Vector3.up * y * 10);
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 1 || Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            keepPostition = true;
        }
        if (keepPostition)
        {
            ResetPosition();
        }
    }
}
