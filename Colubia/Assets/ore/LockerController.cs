using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LockerController : MonoBehaviour
{
    //  子オブジェクト取得用
    public GameObject LockerF;
    public GameObject LockerVision;
    private bool isStay = false;
    PlayerController PlayerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();

        if (transform.localEulerAngles.z == 180)
        {
            LockerF.transform.localEulerAngles = transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCTRL.isInteract == true && isStay)
        {
            LockerF.SetActive(true);
        }
        else
        {
            LockerF.SetActive(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isStay = true;
        LockerF.SetActive(true);// 取得したobjを表示させる
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
        LockerF.SetActive(false);// 取得したobjを非表示にする
    }
}
