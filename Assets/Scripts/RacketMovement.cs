using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    private GameObject smasher;
    private Queue<Vector3> positions = new Queue<Vector3>();
    public Vector3 Movement { get; private set; }
    void Start()
    {
        smasher = gameObject.transform.GetChild(1).gameObject;
        positions.Enqueue(smasher.transform.position);
    }

    private float ConvertAngle(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }
    private Vector3 ConvertVector(Vector3 vector, bool abs = true)
    {
        if (abs) return new Vector3(Mathf.Abs(ConvertAngle(vector.x)), Mathf.Abs(ConvertAngle(vector.y)), Mathf.Abs(ConvertAngle(vector.z)));
        return new Vector3(ConvertAngle(vector.x), ConvertAngle(vector.y), ConvertAngle(vector.z));
    }
    /// <summary>
    /// Calculates average Vector3
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    private Vector3 GetAverage(Queue<Vector3> collection)
    {
        var sum = Vector3.zero;
        foreach (var item in collection)
        {
            sum += item;
        }
        return sum / collection.Count;
    }
    void Update()
    {
        Vector3 position = smasher.transform.position, rotation = smasher.transform.rotation.eulerAngles;
        if (positions.Count == 11) positions.Dequeue();

        var avgPosition = GetAverage(positions);

        //if (currentRot.x < -180)
        //{
        //    currentRot.x = 360 + currentRot.x;
        //}
        //if (currentRot.x > 180)
        //{
        //    currentRot.x = 360 - currentRot.x;
        //}

        //if (currentRot.y < -180)
        //{
        //    currentRot.y = 360 + currentRot.y;
        //}
        //if (currentRot.y > 180)
        //{
        //    currentRot.y = 360 - currentRot.y;
        //}

        //if (currentRot.z < -180)
        //{
        //    currentRot.z = 360 + currentRot.z;
        //}
        //if (currentRot.z > 180)
        //{
        //    currentRot.z = 360 - currentRot.z;
        //}

        Movement = (position - avgPosition) / Time.deltaTime;

        positions.Enqueue(position);
        Debug.Log("Movement: " + Movement);
    }
}
