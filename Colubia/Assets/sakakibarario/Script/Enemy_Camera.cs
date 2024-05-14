using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Camera : MonoBehaviour
{

    Rigidbody2D rb;

    //敵の動き
    private float PRota_speed = 1.0f;
    private float MRota_speed = -1.0f;
    private float speed_P = 50.0f;
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
        MyEnemy = transform.localEulerAngles;
    }

    private void Update()
    {
        if (GameManager.GState == "Pose")
            Moved_Enemy = true;
    }

    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            Debug.Log(direction);
            Debug.Log(Move_end);
            if (Moved_Enemy)
            {
                Move_end = false;

                if (transform.localEulerAngles.z < 360 && transform.localEulerAngles.z > 270)
                {
                    MyEnemy = new Vector3(0,0, 280);
                    
                }
                else
                {
                    MyEnemy = new Vector3(0, 0, 80);
                   
                }

                transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, MyEnemy, speed_P * Time.deltaTime);
                if (transform.localEulerAngles == MyEnemy)
                {
                    countleftTime = 3.0f;
                    countrightTime = 3.0f;
                    Moved_Enemy = false;
                   
                    if (MyEnemy.z == 280)
                    {
                        
                        direction = true;
                        
                    }
                    else
                    {
                        direction = false;
                       
                    }
  
                   
                }
            }
            if (!Moved_Enemy)
            {
                if (direction)
                {
                    countrightTime -= Time.deltaTime; //カウントアップ

                    if (countrightTime < 0)
                    {
                        StartCoroutine(Moveleft());
                    }
                }
                else
                {
                    countleftTime -= Time.deltaTime;  //カウントアップ

                    if (countleftTime < 0)
                    {
                        StartCoroutine(Moveright());
                    }
                }
            }
        }

    }
    IEnumerator Moveleft()
    {
        if (Moved_Enemy)
            yield break;
        this.transform.Rotate(0, 0, this.PRota_speed);
            
        yield return new WaitForSeconds(3.2f);

        if(Move_end)
            direction = false;

        countleftTime = 3.0f;
        Move_end = true;
        yield break;
    }
    IEnumerator Moveright()
    {
        
        this.transform.Rotate(0, 0, this.MRota_speed);
       
        yield return new WaitForSeconds(3.2f);


        if (Move_end)
        {
            direction = true;
            Debug.Log("cccc");
        }
           
        countrightTime = 3.0f;
        Move_end = true;
        yield break;
    }
}
