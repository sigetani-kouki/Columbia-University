using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Camera : MonoBehaviour
{

    Rigidbody2D rb;

    //�G�̓���
    private float speed = 50.0f;
   
    //�J�E���g�p
    private float countleftTime = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
    private bool direction = false;        //true�͉E����

    Vector3 MyEnemy = new Vector3(0,0,0);
    private bool Moved_Enemy = false;
    private bool Move_end = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyEnemy = transform.eulerAngles;//�����ʒu�ۑ�
    }

    private void Update()
    {
        if (GameManager.GState == "Pose")//�|�[�Y�������ꂽ�Ƃ�
            Moved_Enemy = true;

        if (Move_end)//���W�̍X�V
        {
            if (transform.localEulerAngles.z > 180)
            {
                MyEnemy = new Vector3(0, 0, 100);
     �@     }
            else
            {
                MyEnemy = new Vector3(0, 0, 260);      
            }
            Move_end = false;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            //Debug.Log(Move_end);
            if (Moved_Enemy)
            {
                MyEnemy = new Vector3(0, 0, 260);                  
               
                transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, MyEnemy, speed * Time.deltaTime);//MyEnemy�܂Ŋp�x��ύX
                if (transform.eulerAngles == MyEnemy)
                {
                    countleftTime = 3.0f;
                    countrightTime = 3.0f;
                    
                    Moved_Enemy = false;//�|�[�Y��̈ړ�����
                }
            }
            if (!Moved_Enemy)
            {
                if (direction)
                {
                    countrightTime -= Time.deltaTime; //�J�E���g�A�b�v

                    if (countrightTime < 0)
                    {
                        transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, MyEnemy, speed * Time.deltaTime);//MyEnemy�܂Ŋp�x��ύX

                        if (transform.localEulerAngles == MyEnemy)//�ړ�����
                        {
                            countrightTime = 3.0f;//�^�C���̃��Z�b�g
                            Move_end = true;//���W�̍X�V
                            direction = false;//�����̕ύX
                        }

                    }
                }
                else
                {
                    countleftTime -= Time.deltaTime;  //�J�E���g�A�b�v

                    if (countleftTime < 0)
                    {
                        transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, MyEnemy, speed * Time.deltaTime);//MyEnemy�܂Ŋp�x��ύX

                        if (transform.localEulerAngles == MyEnemy) // �ړ�����
                        {
                            countleftTime = 3.0f;//�^�C���̃��Z�b�g
                            Move_end = true;//���W�̍X�V
                            direction = true;//�����̕ύX
                        }
                    }
                }
            }
        }

    }
  
}
