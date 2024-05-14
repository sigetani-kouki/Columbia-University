using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Strength_Security_Guard : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    //GameObject MyEnemy;

    //敵の動き
    public float speed = 2.0f;
    float speed_P = 1.5f;

    //カウント用
    private float countleftTime = 3.0f;   //左向き
    private float countrightTime = 3.0f;   //右向き
    private bool direction = false;        //trueは右向き

    //playerとの距離
    public float reactionDistance = 10.0f;//距離
    private bool isActive = false;
    private bool Moved_Enemy = false;

    Vector2 MyEnemy = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //初期座標を記憶
        MyEnemy = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Player　のゲームオブジェクトを得る
         player = GameObject.FindGameObjectWithTag("Player");
        if(GameManager.GState == "Pose")
        {
            Moved_Enemy = true;//初期位置に戻す
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            //プレイヤーとの距離を求める
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < reactionDistance)
            {
                isActive = true; //アクティブにする
            }
            else
            {
                isActive = false; //非アクティブにする
                if (Moved_Enemy)
                {
                    if(transform.position.x < MyEnemy.x)
                    {
                        this.transform.localScale = new Vector2(-1, 1);//左向き
                    }
                    else if(transform.position.x > MyEnemy.x)
                    {
                        this.transform.localScale = new Vector2(1, 1);//左向き
                    }
                    transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed_P * Time.deltaTime);
                }
                if(MyEnemy.x == transform.position.x)
                {
                    direction = false;
                    Moved_Enemy = false;
                   
                }
            }

            if (!isActive && !Moved_Enemy)//主人公と離れているとき
            {
                if (direction)
                {
                    countrightTime -= Time.deltaTime; //カウントアップ

                    if (countrightTime < 0)
                    {
                        StartCoroutine(Moveright());
                    }
                }
                else
                {
                    countleftTime -= Time.deltaTime;  //カウントアップ

                    if (countleftTime < 0)
                    {
                        StartCoroutine(Moveleft());
                    }
                }
            }
            else if(isActive)//主人公が近くにいた時の動き
            {
               
                Moved_Enemy = true;
                countleftTime = 3.0f;//カウントリセット
                countrightTime = 3.0f;//カウントリセット
                 // PLAYERの位置を取得
                Vector2 targetPos = player.transform.position;
                // PLAYERのx座標
                float x = targetPos.x;
                // ENEMYは、地面を移動させるので座標は常に0とする
                float y = 0;
                // 移動を計算させるための２次元のベクトルを作る
                Vector2 direction = new Vector2(
                    x - transform.position.x, y).normalized;
                // ENEMYのRigidbody2Dに移動速度を指定する
                rb.velocity = direction * speed_P;
                //反転
                if (transform.position.x < player.transform.position.x)
                {
                    this.transform.localScale = new Vector2(-1, 1);//左向き
                }
                else if (transform.position.x > player.transform.position.x)
                {
                    this.transform.localScale = new Vector2(1, 1);//左向き
                }
            }
        }
        else
        {
            rb.Sleep();//動きを止める
        }

    }
    IEnumerator Moveleft()
    {
        this.transform.localScale = new Vector2(1, 1);//左向き
        rb.velocity = new Vector2(-speed, rb.velocity.y);//動きを決める
        yield return new WaitForSeconds(2.0f);
        direction = true;
        countleftTime = 3.0f;
        yield break;
    }
    IEnumerator Moveright()
    {
        this.transform.localScale = new Vector2(-1, 1);//右向き
        rb.velocity = new Vector2(speed, rb.velocity.y);//動きを決める
        yield return new WaitForSeconds(2.0f);
        direction = false;
        countrightTime = 3.0f;
        yield break;
    }
}
