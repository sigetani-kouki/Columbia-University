using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerWork : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    //　プレイヤー移動管理
    public float speed = 3.0f;
    private float playerSpeed;
    private bool Onmove = true;
    private bool MoveLeft = false;
    private bool MoveRight = false;


    //  重力管理
    private bool SwitchGravity = true;

    //  回転管理
    private float PlayerAngle = 0;
    private int PlayerAngleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Onmove)
        {
            //　Aを押したら左に進む
            if (Input.GetKey(KeyCode.A)) 
            { 
                MoveLeft = true;    MoveRight = false;
                playerSpeed = -speed;    
            }

            //　Bを押したら左に進む
            else if (Input.GetKey(KeyCode.D))
            {
                MoveRight = true; MoveLeft = false;
                playerSpeed = speed;
            }
            else playerSpeed = 0;
        }

        if (MoveRight) transform.eulerAngles = new Vector3(0, 0,);
        if (MoveLeft) transform.eulerAngles = new Vector3(0, 180,);


        //　Spaceを押したら重力を反転させ、グラフィックの向きを整える
        if (SwitchGravity)
        {
            if (Input.GetKey(KeyCode.Space))
                GravityChange();
        }
            

        rigidbody2D.velocity = new Vector2(playerSpeed, rigidbody2D.velocity.y);
    }

    void GravityChange()
    {
        playerSpeed = 0;//  移動中に反転できないようにできる
        SwitchGravity = false;
        Onmove = false;

        //　重力を反転させる
        rigidbody2D.gravityScale *= -1;

        StartCoroutine(PlayerRotate());
    }

    IEnumerator PlayerRotate()
    {
        yield return new WaitForSeconds(0.25f);

        //  PlayerAngleCountを初期化させて数字を大きくなりすぎないようにする
        if (PlayerAngleCount >= 2) PlayerAngleCount = 0;
        //  PlayerCountを初期化させて数字を大きくなりすぎないようにする
        if (PlayerAngle >= 360) PlayerAngle = 0;


        //  これを使用して最大角度を変更させることで、天井か床に頭で着地しないようにする
        PlayerAngleCount += 1;

        //　プレイヤーの向きをジョジョに変える
        for (; PlayerAngle <= 180 * PlayerAngleCount;) 
        {
            //  1°づつ回転させる
            transform.rotation = Quaternion.Euler(0, 0, PlayerAngle);
            PlayerAngle += 3.0f;

            //  次の回転まで少し待機
            yield return new WaitForSeconds(0.000025f);
        }

        //  回転後、左右が逆なので反転させる
        FlipX();

        //  空中で回転できないように少し待機
        yield return new WaitForSeconds(0.25f);
        SwitchGravity = true;
        Onmove = true; //着地後に移動できるようにする
    }

    void FlipX()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == false)
            this.GetComponent<SpriteRenderer>().flipX = true;
        else
            this.GetComponent<SpriteRenderer>().flipX = false;

    }
}