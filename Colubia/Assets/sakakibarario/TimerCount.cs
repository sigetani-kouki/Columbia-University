using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCount : MonoBehaviour
{
    //秒カウントダウン
    private float countupsecond = 50;

    //分カウントダウン
    private int countupinute = 9;


    //時間を表示するText型の変数
    public Text timeText;

    //ポーズしてるかどうか
    public static bool isPose = false;

    private void Start()
    {
       
    }

    //Uodate is called once per frame
    void Update()
    {
       
          
        //クリックされたとき
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //ポーズ中にクリックされたとき
            if (isPose)
            {
                //ポーズ状態を解除する
                FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Playing);
                isPose = false;
              
            }
            //進行中にクリックされたとき
            else
            {
                //ポーズ状態にする
                FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Pose);
                isPose = true;
            }
        }


        if (GameManager.GState != "Playing")
        {
            return;
        }
        //ポーズ中かどうか
        if (isPose)
        {
            //ポーズ中であることを表示
            //timeText.text = "ポーズ中";
            //カウントダウンしない
            return;
        }

        //時間をカウントする
        countupsecond += Time.deltaTime;

        if (countupsecond >= 60)
        {
            countupinute++;
            countupsecond = 0.0f;
        }

        //時間を表示する
        if (countupsecond < 10)
        {
            timeText.text = countupinute.ToString("00") + ":0" + countupsecond.ToString("f2");
        }
        else
        {
            timeText.text = countupinute.ToString("00") + ":" + countupsecond.ToString("f2");
        }

        
    }
}
