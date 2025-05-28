using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    void Update()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
