using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.instance.colorEnemy;
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);

        Vector3 newPos = transform.position + Vector3.up * moveInput * moveSpeed * Time.deltaTime;

        newPos.y = Mathf.Clamp(newPos.y, -4.14f, 4.14f);

        transform.position = newPos;
    }


}
