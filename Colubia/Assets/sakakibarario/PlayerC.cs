using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    Rigidbody2D rb;
    
    public BoxCollider2D bx;
    public LayerMask GroundLayer;
    float axisH = 0.0f;
    public float speed = 3.0f;  //移動速度
    public float jump = 6.0f;   //ジャンプ力

    public bool ongrond = false;             //地面判定
    bool gojump = false;                     //ジャンプ判定
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //水平方向のチェック
        axisH = Input.GetAxisRaw("Horizontal");

        //向きの調整
        if (axisH > 0.0f)
        {
            //右移動
            // Debug.Log("右移動");
            transform.localScale = new Vector2(1, 1);
            
        }
        if (axisH < 0.0f)
        {
            //左移動
            //Debug.Log("左移動");
            transform.localScale = new Vector2(-1, 1);
           
        }
        //キャラクターのジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {

        //地上判定
        ongrond = Physics2D.Linecast(transform.position,
                                    transform.position - (transform.up * 0.1f),
                                    GroundLayer);
        if (ongrond || axisH != 0 )
        {
            //地上or速度が０ではないor攻撃中ではない
            //速度を更新
            rb.velocity = new Vector2(axisH * speed, rb.velocity.y);
        }
        if (ongrond && gojump)
        {
            //地上かつジャンプキーが押されたとき
            //ジャンプする
            Debug.Log("ジャンプ");
            Vector2 jumpPw = new Vector2(0, jump);      //ジャンプさせるベクトル
            rb.AddForce(jumpPw, ForceMode2D.Impulse);   //瞬間的な力を加える
            gojump = false; //ジャンプフラグをおろす
        }
    }
    //主人公に動き
    void Jump()//ジャンプ
    {
        gojump = true; //ジャンプフラグを立てる
        Debug.Log(ongrond);
    }
}
