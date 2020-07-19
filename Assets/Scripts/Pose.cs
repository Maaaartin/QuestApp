using UnityEngine;

/// <summary>
/// Sets initial position to GAmeObject after 15 frames
/// </summary>
public class Pose : MonoBehaviour
{
    private byte counter = 0;

    public GameObject patternObject;
    public Vector3 positionOffset;
    public delegate void ObjectPose(Vector3 position);
    public event ObjectPose OnObjectPosed;

    void Update()
    {
        if (counter < 15) counter++;
        else if (counter == 15)
        {
            counter++;
            if (patternObject != null) transform.position = patternObject.transform.position + positionOffset;
            OnObjectPosed?.Invoke(transform.position);
        }
    }
}
