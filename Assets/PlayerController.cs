using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    GameObject RearWheel;
    [SerializeField]
    GameObject FrontWheel;
    [SerializeField]
    GameObject Head;
    [SerializeField]
    float wheelieForce = 10;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    LayerMask checkpointLayer;
    Vector3 rotateVector = new(1,0,0);
    int score;
    bool holdingMouse = false;

    void Update()
    {
        Vector2 gravity = Physics2D.gravity;
        if (holdingMouse == true)
        {
            transform.RotateAround(RearWheel.transform.position, Vector3.forward, wheelieForce * Time.deltaTime);
            FrontWheel.GetComponent<Rigidbody2D>().gravityScale = 0;
            Head.GetComponent<Rigidbody2D>().gravityScale = 0;
            wheelieForce++;
        }
        else
        {
            FrontWheel.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            Head.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            wheelieForce = 10;
        }
        if (Physics2D.OverlapCircle(FrontWheel.transform.position, 0.1f, checkpointLayer))
        {
            scoreText.text = "0";
        }
        if (Physics2D.OverlapCircle(Head.transform.position, 0.1f, groundLayer))
        {
            SceneManager.LoadScene(1);
        }
    }


    void OnFire(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            holdingMouse = true;
        }
        else
        {
            holdingMouse = false;
        }
    }
}
