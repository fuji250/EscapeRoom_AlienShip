using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCanvas : MonoBehaviour
{
    [SerializeField] GameObject panel = default;
    [SerializeField] Transform objParent = default;
    GameObject zoomObj = default;

    // やること
    // ・アイテムを選択していたら

    private void Start()
    {
        panel.SetActive(false);
        
    }

    // ・Zoomボタンが押されたら、パネルを表示
    public void ShowPanel()
    {
        //アイテム二度目のタップでパネル閉じる
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
            //アイテムを表示
            //ObjParentにアイテムを生成する
            GameObject zoomObjPrefab = ItemGenerater.instance.GetZoomItem(item.type);
            zoomObj = Instantiate(zoomObjPrefab,objParent);
        }
    }

    // ・（アイテムを表示）
    // ・Closeボタンが押されたら、パネルを非表示
    public void ClosePanel()
    {
        panel.SetActive(false);
        Destroy(zoomObj);
    }
}