using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomObj : MonoBehaviour
{
    [SerializeField] Camera zoomCamera = default;
    // クリックしたら、用意してあるカメラに切り替える
    public void OnClickThis()
    {
        Debug.Log("カメラ切り替え");
        CameraManager.instance.SetZoomCamera(zoomCamera);
    }
}