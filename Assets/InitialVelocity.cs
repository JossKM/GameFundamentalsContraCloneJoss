using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
    float speed = 10.0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
    }
}
