using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 pos = transform.position;
            pos.x -= speed;
            transform.position = pos;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Input.GetKey(KeyCode.D))
        {
            Vector2 pos = transform.position;
            pos.x += speed;
            transform.position = pos;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }
    
}
