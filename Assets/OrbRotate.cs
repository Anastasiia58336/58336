using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotate : MonoBehaviour
{
    public Transform center;
    public float rotationSpeed = 100f;
    public float radius = 1.5f;
    private float angle;
    void Update()
    {
        if (center == null) return;
        angle += rotationSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
        transform.position = (Vector2)center.position + offset;
    }
}
