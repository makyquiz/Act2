using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (Input.GetKey(KeyCode.W))
            y += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            y -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            x += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            x -= speed * Time.deltaTime;

        transform.position = new Vector3(x, y, z);
    }
}
