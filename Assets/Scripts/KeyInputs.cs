using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x, y = transform.position.y, z = transform.position.z;
        float speed = 0.01f;
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(x + speed, y, z);
        }

       else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(x - speed, y, z);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            transform.position = new Vector3(x, y + speed, z);
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            transform.position = new Vector3(x, y - speed, z);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(x, y, z + speed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(x, y, z - speed);
        }
        else
        {
            transform.position = transform.position;
        }
    }
}
