using System.Collections;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Running());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Running()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.0f);
            Debug.Log("i am running");
        }
    }
}
