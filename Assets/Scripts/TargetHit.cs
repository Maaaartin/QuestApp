using System.Collections;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public GameObject collisionObject;
    public Texture[] textures;
    private int currentIndex;
    private Pose pose;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentIndex = 0;
        pose = GetComponent<Pose>();
        pose.OnObjectPosed += Pose_OnObjectPosed;
    }

    private int GetIndex()
    {
        var newIndex = currentIndex == textures.Length - 1 ? 0 : currentIndex + 1;
        currentIndex = newIndex;
        return newIndex;
    }
    private void Pose_OnObjectPosed(Vector3 position)
    {
        StartCoroutine(Replace());
    }

    /// <summary>
    /// Changes object position
    /// </summary>
    /// <returns></returns>
    IEnumerator Replace()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            meshRenderer.material.mainTexture = textures[GetIndex()];
            var bounds = transform.parent.GetComponent<Renderer>().bounds;
            transform.position = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z) - 0.01f);
        }
    }
}
