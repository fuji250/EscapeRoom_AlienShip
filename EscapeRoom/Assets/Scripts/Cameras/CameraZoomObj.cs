using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomObj : MonoBehaviour
{
    [SerializeField] Transform zoomTransform = default;
    // �N���b�N������A�p�ӂ��Ă���J�����ɐ؂�ւ���
    public void OnClickThis()
    {
        Debug.Log("�J�����؂�ւ�");
        CameraManager.instance.SetZoomCamera(zoomTransform);
    }
}