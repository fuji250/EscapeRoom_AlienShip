using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCanvas : MonoBehaviour
{
    [SerializeField] GameObject panel = default;
    [SerializeField] Transform objParent = default;
    GameObject zoomObj = default;

    // ��邱��
    // �E�A�C�e����I�����Ă�����

    private void Start()
    {
        panel.SetActive(false);
        
    }

    // �EZoom�{�^���������ꂽ��A�p�l����\��
    public void ShowPanel()
    {
        //�A�C�e����x�ڂ̃^�b�v�Ńp�l������
        if (panel.activeSelf == true)
        {
            ClosePanel();
            return;
        }
        Item item = ItemBox.instance.GetSelectedItem();
        if (item != null)
        {
            Destroy(zoomObj);
            panel.SetActive(true);
            //�A�C�e����\��
            //ObjParent�ɃA�C�e���𐶐�����
            GameObject zoomObjPrefab = ItemGenerater.instance.GetZoomItem(item.type);
            zoomObj = Instantiate(zoomObjPrefab,objParent);
        }
    }

    // �E�i�A�C�e����\���j
    // �EClose�{�^���������ꂽ��A�p�l�����\��
    public void ClosePanel()
    {
        panel.SetActive(false);
        Destroy(zoomObj);
    }
}