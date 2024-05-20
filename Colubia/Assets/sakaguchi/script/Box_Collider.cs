using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Collider : MonoBehaviour
{
    public BoxCollider2D bcol;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(bcol.enabled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            bcol.enabled = false;
            Debug.Log(bcol.enabled);
        }
        else
        {
            bcol.enabled = true;
        } 
    }
}
