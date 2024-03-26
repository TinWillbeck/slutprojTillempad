using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField]
    GameObject groundCheck;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float speed = 0.1f;
    Vector2 movingVector = new(-1, 0);
    bool isMoving = false;
    void Start()
    {
        movingVector.x = movingVector.x * speed;
    }

    void Update()
    {
        if (isMoving == true)
        {
            transform.Translate(movingVector);
        }
        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.2f, groundLayer) == true)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
