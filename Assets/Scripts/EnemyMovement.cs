using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Transform ball;

    void Update()
    {
        float targetY = Mathf.Clamp(ball.position.y, -4.14f, 4.14f);
        Vector2 targetPosition = new Vector2(transform.position.x, targetY);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
}
