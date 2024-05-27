using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    //  子オブジェクト取得用
    public GameObject PaperF;
    public GameObject PaperLook;
    public GameObject PaperBackGround;
    public GameObject PaperESC;

    PlayerController PlayerCTRL;

    private bool isLook = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();

        if (transform.localEulerAngles.z == 180)
        {
            PaperF.transform.localEulerAngles = transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCTRL.isInteract == true && isLook)
        {
            PaperF.SetActive(true);
        }
        else
        {
            PaperF.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLook = true;
        PaperF.SetActive(true);// 取得したobjを表示させる
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLook = false;
        PaperF.SetActive(false);// 取得したobjを非表示にする
    }
}
