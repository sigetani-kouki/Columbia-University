using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_security_guard : MonoBehaviour
{
    Rigidbody2D rb;

    //敵の動き
    public float speed = 2.5f;

    //カウント用
    private float countleftTime  = 3.0f;   //左向き
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
