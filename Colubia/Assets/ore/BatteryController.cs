using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    //  �q�I�u�W�F�N�g�擾�p
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
        BatteryF.SetActive(true);// �擾����obj��\��������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BatteryF.SetActive(false);// �擾����obj���\���ɂ���
    }

    public void objDestroy()
    {
        Destroy(this.gameObject);
    }
}
