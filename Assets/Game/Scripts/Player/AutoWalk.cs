using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public float speed = 0.5f;
    public float stopAtZ = 38.5f;

    void Update()
    {
        if (transform.position.z >= stopAtZ)
        {
            return;
        }

        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}