using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_area : MonoBehaviour
{
    private bool inarea = false;
    public float count_area = 1.5f;
    //public BoxCollider2D bx1;
    //public BoxCollider2D bx2;


    private void Start()
    {
        //bx1 = GetComponent<BoxCollider2D>();
        //bx2 = GetComponent<BoxCollider2D>();
    }
  
    private void FixedUpdate()
    {
        if(inarea)
        {
            inarea = true;
            count_area -= Time.deltaTime;//カウント
            if (count_area < 0.5)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 130);//色を変更（赤）
            }
            if (count_area < 0)
            {
                // ゲームオーバー処理を呼ぶ
                FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Over);
            }
        }
        else
        {
            count_area = 1.5f;//エリアタイムのリセット
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(248, 255, 93, 130);//色のリセット
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")// 主人公
        {
         　inarea = true;
        }
        else
        {
            inarea = false;
        }
    }
}
