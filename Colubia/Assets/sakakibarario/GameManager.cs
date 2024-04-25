using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲームステート
    public enum GameState
    {
        Playing,
        Clear,
        Over,
        home
    }

    // 現在のゲーム進行状態
    public GameState currentState = GameState.home;

    public static string GState = "home";//ゲームの状態

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            dispatch(GameState.Playing);
    }

    // 状態による振り分け処理
    public void dispatch(GameState state)
    {
        currentState = state;
        switch (state)
        {
            case GameState.Playing:
                GameStart();
                break;
            case GameState.Clear:
                GameClear();
                break;
            case GameState.Over:
                GameOver();
                break;
            case GameState.home:

                break;
        }

    }
    // オープニング処理
    void GameOpening()
    {

    }

    // ゲームスタート処理
    void GameStart()
    {
        GState = "Playing";
        Debug.Log("playing");
    }

    // ゲームクリアー処理
    void GameClear()
    {
        GState = "GameClear";
        Debug.Log("GameClear");
    }

    // ゲームオーバー処理
    void GameOver()
    {
        GState = "GameOver";
        Debug.Log("gameover");
    }

}
