using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Vector2 position;
    public GameObject LockerVision;

    LockerController lockerController;

    SpriteRenderer sp;
    Color spriteColor;

    //　プレイヤー管理
    public float hideduration = 0.005f;
    public float speed = 3.0f;
    private float playerX;
    private bool Onmove = true;
    private bool isMoveLeft = false;
    private bool isMoveRight = false;

    //　ロッカー系
    public bool isInteract = true;
    public bool inLocker = false;


    //  重力管理
    private bool SwitchGravity = true;

    //  回転管理
    private float PlayerAngle = 0;
    private int PlayerAngleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lockerController = GameObject.FindWithTag("Locker").GetComponent<LockerController>();
        sp = GetComponent<SpriteRenderer>();
        spriteColor = sp.color;

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Onmove)
        {
            //　Aを押したら左に進む
            if (Input.GetKey(KeyCode.A)) 
            { 
                isMoveLeft = true;    isMoveRight = false;
                playerX = -speed;    
            }

            //　Bを押したら左に進む
            else if (Input.GetKey(KeyCode.D))
            {
                isMoveRight = true; isMoveLeft = false;
                playerX = speed;
            }
            else playerX = 0;
        }

        //  キャラクターが進行方向に進むようにする
        if (isMoveRight) transform.localScale = new Vector2(-0.4f, 0.4f);
        if (isMoveLeft)  transform.localScale = new Vector2(0.4f, 0.4f);


        //　Spaceを押したら重力を反転させ、グラフィックの向きを整える
        if (SwitchGravity)
        {
            if (Input.GetKey(KeyCode.Space))
                GravityChange();
        }

        //  ロッカーのボタンガイドがアクティブなら
        if (lockerController.childObj.activeSelf) 
        {
            if (Input.GetKey(KeyCode.F) && isInteract == true) 
            {
                isInteract = false;
                StartCoroutine(Interactive("Locker"));

                //  隠れる
                if(inLocker == false)
                {
                    inLocker = true;
                    Onmove = false;      //　主人公を止める
                    StartCoroutine(hideCTRL(0));    //　主人公を非表示にする
                    StartCoroutine(LockerActivate(true));
                }
                //　表に出る
                else
                {
                    inLocker = false;
                    Onmove = true;      //　主人公を動けるようにする
                    StartCoroutine(hideCTRL(1));    //　主人公を表示する
                    StartCoroutine(LockerActivate(false)); 
                }
            }
        }
        rb2D.velocity = new Vector2(playerX, rb2D.velocity.y);
    }

    void GravityChange()
    {
        playerX = 0;//  移動中に反転できないようにできる
        SwitchGravity = false;
        Onmove = false;
        isInteract = false;

        //　重力を反転させる
        rb2D.gravityScale *= -1;

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
        isInteract = true;
    }

    void FlipX()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == false)
            this.GetComponent<SpriteRenderer>().flipX = true;
        else
            this.GetComponent<SpriteRenderer>().flipX = false;

    }

    IEnumerator Interactive(string anyOBJ)
    {
        Debug.Log("F");

        if (anyOBJ == "Locker")
        {
            //　ロッカーのX座標を「主人公とは無関係」のベクター型変数に保存
            position.x = lockerController.transform.position.x;
            //　保存してた座標をプレイヤーに入れる
            transform.position = position;

            yield return new WaitForSeconds(4f);
            isInteract = true;
        } 
    }

    IEnumerator hideCTRL(float targetAlpha)
    {
        Debug.Log("aaa");
        while (!Mathf.Approximately(spriteColor.a, targetAlpha))
        {
            float changePerFrame = Time.deltaTime / hideduration;
            spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, changePerFrame);
            sp.color = spriteColor;
            yield return null;
        }
    }

    IEnumerator LockerActivate(bool activate)
    {
        yield return new WaitForSeconds(0.25f);

        if (activate) 
            LockerVision.SetActive(true);
        else
            LockerVision.SetActive(false);
    }

}