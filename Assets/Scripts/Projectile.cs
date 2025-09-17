using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
