using UnityEngine;

/// <summary>
/// Displays FPS
/// </summary>
public class FPSDisplay : MonoBehaviour
{
    private TextMesh textMesh;
    private byte counter = 1;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        transform.localPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 10)
        {
            counter = 0;
            textMesh.text = string.Format("FPS: {0:F2}", 1f / Time.unscaledDeltaTime);
        }
        counter++;
    }
}