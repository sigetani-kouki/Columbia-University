using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] Transform playerTr; // プレイヤーのTransformをInspectorから入れる

    private void Update()
    {
        // カメラをプレイヤーの場所へ
        transform.position = new Vector3(playerTr.position.x, playerTr.position.y, -5f);
    }
}
