using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Camera : MonoBehaviour
{

    Rigidbody2D rb;

    //敵の動き
    private float speed = 50.0f;
   
    //カウント用
    private float countleftTime = 3.0f;   //左向き
    private float countrightTime = 3.0f;   //右向き
    private bool direction = false;        //trueは右向き

    Vector3 MyEnemy = new Vector3(0,0,0);
    private bool Moved_Enemy = false;
    private bool Move_end = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyEnemy = transform.eulerAngles;//初期位置保存
    }

    private void Update()
    {
        if (GameManager.GState == "Pose")//ポーズを押されたとき
            Moved_Enemy = true;

        if (Move_end)//座標の更新
        {
            if (transform.localEulerAngles.z > 180)
            {
                MyEnemy = new Vector3(0, 0, 100);
     　     }
            else
            {
                MyEnemy = new Vector3(0, 0, 260);      
            }
            Move_end = false;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            //Debug.Log(Move_end);
            if (Moved_Enemy)
            {
                MyEnemy = new Vector3(0, 0, 260);                  
               
                transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, MyEnemy, speed * Time.deltaTime);//MyEnemyまで角度を変更
                if (transform.eulerAngles == MyEnemy)
                {
                    countleftTime = 3.0f;
                    countrightTime = 3.0f;
                    
                    Moved_Enemy = false;//ポーズ後の移動完了
                }
            }
            if (!Moved_Enemy)
            {
                if (direction)
                {
                    countrightTime -= Time.deltaTime; //カウントアップ

                    if (countrightTime < 0)
                    {
                        transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, MyEnemy, speed * Time.deltaTime);//MyEnemyまで角度を変更

                        if (transform.localEulerAngles == MyEnemy)//移動完了
                        {
                            countrightTime = 3.0f;//タイムのリセット
                            Move_end = true;//座標の更新
                            direction = false;//向きの変更
                        }

                    }
                }
                else
                {
                    countleftTime -= Time.deltaTime;  //カウントアップ

                    if (countleftTime < 0)
                    {
                        transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, MyEnemy, speed * Time.deltaTime);//MyEnemyまで角度を変更

                        if (transform.localEulerAngles == MyEnemy) // 移動完了
                        {
                            countleftTime = 3.0f;//タイムのリセット
                            Move_end = true;//座標の更新
                            direction = true;//向きの変更
                        }
                    }
                }
            }
        }

    }
  
}
