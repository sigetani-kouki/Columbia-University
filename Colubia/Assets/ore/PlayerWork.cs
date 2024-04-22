using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWork : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    //　プレイヤー速度管理
    public float speed = 3.0f;
    private float playerSpeed;

    private bool SwitchGravity = true;
    public float Gravity = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //　Aを押したら左に進む
        if (Input.GetKey(KeyCode.A)) playerSpeed = -speed;
        //　Bを押したら左に進む
        else if (Input.GetKey(KeyCode.D)) playerSpeed = speed;
        else playerSpeed = 0;

        //　Spaceを押したら重力を反転させ、グラフィックの向きを整える
        if (SwitchGravity)
        {
            if (Input.GetKey(KeyCode.Space))
                GravityChange();
        }
            

        rigidbody2D.velocity = new Vector2(playerSpeed, rigidbody2D.velocity.y);
    }

    void GravityChange()
    {
        SwitchGravity = false;

        //　重力を反転させる
        rigidbody2D.gravityScale *= -1;
        Debug.Log("a");

        StartCoroutine(PlayerRotate());
    }

    IEnumerator PlayerRotate()
    {
        yield return new WaitForSeconds(0.25f);

        //　プレイヤーの向きを変える
        transform.Rotate(0, 0, 180);

        SwitchGravity = true;
    }
}
