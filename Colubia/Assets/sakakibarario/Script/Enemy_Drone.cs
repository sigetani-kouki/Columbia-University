using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drone : MonoBehaviour
{
    Rigidbody2D rb;

    //敵の動き
    public float speed = 7.0f;

    //カウント用
    private float countleftTime = 3.0f;   //左向き
    private float countrightTime = 3.0f;   //右向き
    private bool direction = false;        //trueは右向き


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            if (direction)
            {
                countrightTime -= Time.deltaTime; //カウントアップ
              
                if (countrightTime < 0)
                {
                    StartCoroutine(Moveright());//右向き
                }
            }
            else
            {
                countleftTime -= Time.deltaTime;  //カウントアップ
                
                if (countleftTime < 0)
                {
                    StartCoroutine(Moveleft());//左向き
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
       
        this.transform.localScale = new Vector2(1, 1);//向きを調整
        rb.velocity = new Vector2(-speed, rb.velocity.y);//動きを決める
        yield return new WaitForSeconds(3.0f);//move time
        rb.velocity = new Vector2(0, rb.velocity.y);//動きを止める
        countleftTime = 3.0f;//リセット
        direction = true;
        yield break;
    }
    IEnumerator Moveright()
    {
       
        this.transform.localScale = new Vector2(-1, 1);//向きを調整
        rb.velocity = new Vector2(speed, rb.velocity.y);//動きを決める
        yield return new WaitForSeconds(3.0f);//move time
        rb.velocity = new Vector2(0, rb.velocity.y);//動きを止める
        countrightTime = 3.0f;//リセット
        direction = false;
        yield break;
    }
}
