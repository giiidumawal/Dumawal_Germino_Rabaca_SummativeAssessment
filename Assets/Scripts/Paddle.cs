using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]float speed;
    float height;

    string input;
    public bool isRight;

    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 vs2 = Vector2.zero;

        if (isRightPaddle)
        {
            vs2 = new Vector2 (GameManager.topRight.x,0);
            vs2 -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            vs2 = new Vector2(GameManager.bottomLeft.x, 0);
            vs2 += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }
        transform.position = vs2;
        transform.name = input;

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if(transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
