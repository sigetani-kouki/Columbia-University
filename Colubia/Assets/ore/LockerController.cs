using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class LockerController : MonoBehaviour
{
    //  子オブジェクト取得用
    public GameObject childObj;
    private bool isStay = false;

    PlayerController PlayerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCTRL.isInteract == true && isStay)
        {
            childObj.SetActive(true);
        }
        else
        {
            childObj.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isStay = true;
        childObj.SetActive(true);// 取得したobjを表示させる
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
        childObj.SetActive(false);// 取得したobjを非表示にする
    }
}
