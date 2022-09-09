using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("Paddle Controls")]
    public KeyCode paddle1Key;
    public KeyCode paddle2Key;
    public KeyCode paddle3Key;
    public KeyCode paddle4Key;

    [Header("Physics")]
    public float paddleForce;
    public float windUpModifier;
    public float paddleRetractSpeed;
    [Range(0,1)]
    public float paddleResetSpeed;
    public Vector2 paddleXClamp;

    [Header("Game Objects")]
    public GameObject paddle1Obj;
    public GameObject paddle2Obj;
    public GameObject paddle3Obj;
    public GameObject paddle4Obj;



    Rigidbody2D rb1;
    Rigidbody2D rb2;
    Rigidbody2D rb3;
    Rigidbody2D rb4;
    float startingXPos;


    void Start()
    {
        rb1 = paddle1Obj.GetComponent<Rigidbody2D>();
        rb2 = paddle2Obj.GetComponent<Rigidbody2D>();
        rb3 = paddle3Obj.GetComponent<Rigidbody2D>();
        rb4 = paddle4Obj.GetComponent<Rigidbody2D>();

        startingXPos = paddle1Obj.transform.position.x;
    }



    void Update()
    {
        // ------------   RESET PADDLE POSITIONS     ------------- //
        if(!Input.GetKey(paddle1Key)) ResetPaddle(rb1);
        if(!Input.GetKey(paddle2Key)) ResetPaddle(rb2);
        if(!Input.GetKey(paddle3Key)) ResetPaddle(rb3);
        if(!Input.GetKey(paddle4Key)) ResetPaddle(rb4);

        // ------------   CHECK PADDLE RELEASE     ------------- //
        if(Input.GetKeyUp(paddle1Key)) ReleasePaddle(rb1);
        if(Input.GetKeyUp(paddle2Key)) ReleasePaddle(rb2);
        if(Input.GetKeyUp(paddle3Key)) ReleasePaddle(rb3);
        if(Input.GetKeyUp(paddle4Key)) ReleasePaddle(rb4);

        // ------------   CHECK PADDLE WIND UP     ------------- //
        if(Input.GetKey(paddle1Key) && !Input.GetKeyUp(paddle1Key)) WindPaddle(rb1);
        if(Input.GetKey(paddle2Key) && !Input.GetKeyUp(paddle2Key)) WindPaddle(rb2);
        if(Input.GetKey(paddle3Key) && !Input.GetKeyUp(paddle3Key)) WindPaddle(rb3);
        if(Input.GetKey(paddle4Key) && !Input.GetKeyUp(paddle4Key)) WindPaddle(rb4);

        // ------------   CLAMP PADDLE POSITIONS   ------------- //
        ClampPaddlePosition(rb1);
        ClampPaddlePosition(rb2);
        ClampPaddlePosition(rb3);
        ClampPaddlePosition(rb4);

    }



    void ReleasePaddle(Rigidbody2D rb)
    {
        float windUpAmount = startingXPos - rb.transform.position.x;
        rb.AddForce(Vector2.right * (paddleForce  + (windUpModifier * windUpAmount)));
    }



    void WindPaddle(Rigidbody2D rb)
    {
        Vector2 movement = Vector2.left * paddleRetractSpeed * Time.deltaTime;
        Vector2 pos2D = new Vector2(rb.transform.position.x, rb.transform.position.y);
        rb.MovePosition(pos2D + movement);
    }



    void ResetPaddle(Rigidbody2D rb)
    {
        float newXPos = Mathf.Lerp(startingXPos, rb.transform.position.x, paddleResetSpeed);
        rb.MovePosition(new Vector2(newXPos, rb.transform.position.y));
    }


    void ClampPaddlePosition(Rigidbody2D rb)
    {
        // check beyond left
        if(rb.transform.position.x < paddleXClamp.x) {
            rb.velocity = Vector2.zero;
            rb.MovePosition(new Vector2(paddleXClamp.x, rb.transform.position.y));
        }
        // check beyond right
        if(rb.transform.position.x > paddleXClamp.y) {
            rb.velocity = Vector2.zero;
            rb.MovePosition(new Vector2(paddleXClamp.y, rb.transform.position.y));
        }
    }
}
