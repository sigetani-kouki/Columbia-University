using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    //  子オブジェクト取得用
    public GameObject BatteryF;
    PlayerController PlayerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();

        if (transform.localEulerAngles.z == 180)
        {
            BatteryF.transform.localEulerAngles = transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerCTRL.isInteract == true )
        //{
        //    BatteryF.SetActive(true);
        //}
        //else
        //{
        //    BatteryF.SetActive(false);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BatteryF.SetActive(true);// 取得したobjを表示させる
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BatteryF.SetActive(false);// 取得したobjを非表示にする
    }

    public void objDestroy()
    {
        Destroy(this.gameObject);
    }
}
