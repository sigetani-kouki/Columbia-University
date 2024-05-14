using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeCTRL : MonoBehaviour
{
    SpriteRenderer sp;
    Color spriteColor;
    float duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        spriteColor = sp.color;
        StartCoroutine(Fade(1));
    }

    IEnumerator Fade(float targetAlpha)
    {
        while (!Mathf.Approximately(spriteColor.a, targetAlpha))
        {
            float changePerFrame = Time.deltaTime / duration;
            spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, changePerFrame);
            sp.color = spriteColor;
            yield return null;
        }
    }

}
