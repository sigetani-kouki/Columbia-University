using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon_Collider : MonoBehaviour
{
    public PolygonCollider2D pcol;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(pcol.enabled);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pcol.enabled = false;
            Debug.Log(pcol.enabled);
        }
        else
        {
            pcol.enabled = true;
        }
    }
}
