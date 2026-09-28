using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        transform.position = playerTransform.position * 0.1f;
    }
}
