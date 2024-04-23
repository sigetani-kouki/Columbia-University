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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
       
    }

    // ゲームクリアー処理
    void GameClear()
    {
      
    }

    // ゲームオーバー処理
    void GameOver()
    {
        Debug.Log("gameover");
    }

}
