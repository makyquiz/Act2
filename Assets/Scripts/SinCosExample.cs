using System.ComponentModel.Design;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SinCosExample : MonoBehaviour
{
    public Projectile prefab;

    float degrees = 360;
    public int directions;

    public Transform target;
    public float powerUpRange = 0.5f;

    private bool powerUpUsed = false;

    void Start()
    {
        InvokeRepeating("Fire", 1, 2f);
    }

    void Update()
    {
        var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2)
        + Mathf.Pow(target.position.y - this.transform.position.y, 2));

        if (!powerUpUsed && distance < powerUpRange)
        {
            directions++;
            powerUpUsed = true;

            target.gameObject.SetActive(false);
        }
    }

    void Fire()
    {
        foreach (var angle in GetAngles())
        {
            var projectile = Instantiate(prefab, this.transform.position, Quaternion.identity);
            var actualRadians = angle * Mathf.Deg2Rad;
            projectile.direction = new Vector3(Mathf.Cos(actualRadians), Mathf.Sin(actualRadians), 0);
            projectile.name = $"Projectile Angle {angle}";
        }
    }

    public float[] GetAngles()
    {
        var angles = new float[directions];
        angles[0] = 0;
        var currentAngle = 0f;
        var degDrag = degrees / directions;
        for (int i = 1; i < directions; i++)
        {
            currentAngle += degDrag;
            angles[i] = currentAngle;
        }
        return angles;

    }
}
