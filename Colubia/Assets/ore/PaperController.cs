using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    //  子オブジェクト取得用
    public GameObject PaperF;
    public GameObject PaperLook;
    public GameObject PaperBackGround;

    PlayerController PlayerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PaperF.SetActive(true);// 取得したobjを表示させる
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PaperF.SetActive(false);// 取得したobjを非表示にする
    }
}
