using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Camera : MonoBehaviour
{

    Rigidbody2D rb;

    //敵の動き
    private float PRota_speed = 1.0f;
    private float MRota_speed = -1.0f;
    //カウント用
    private float countleftTime = 3.0f;   //左向き
    private float countrightTime = 3.0f;   //右向き
    private bool direction = false;        //trueは右向き


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
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
           
        }

    }
    IEnumerator Moveleft()
    {
            this.transform.Rotate(0, 0, this.PRota_speed);
            
            yield return new WaitForSeconds(3.2f);
        
        direction = true;
        Debug.Log("aaa");
        countleftTime = 3.0f;
        yield break;
    }
    IEnumerator Moveright()
    {
        
            this.transform.Rotate(0, 0, this.MRota_speed);
           
            yield return new WaitForSeconds(3.2f);
        
        direction = false;
        Debug.Log("bbb");
        countrightTime = 3.0f;
        yield break;
    }
}
