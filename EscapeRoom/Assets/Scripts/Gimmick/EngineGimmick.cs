using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineGimmick : MonoBehaviour
{
    //ギミックを解除するアイテムを外で設定できるようにする
    [SerializeField] Item.Type clearItem = default;

    private bool isOpen = false;

    private BoxCollider code1;

    public List<Collider> codesColiderList;
    public List<GameObject> onCodesList;
    public List<GameObject> offCodesList;

    private Collider clickColider;
    
    private Camera  mainCamera= default;

    private void Start()
    {
        mainCamera= Camera.main;

        foreach (var onCode in onCodesList)
        {
            onCode.SetActive(false);
        }

        foreach (var offCode in offCodesList)
        {
            offCode.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickCode();
        }
    }

    public void OnClickObj()
    {
        //TODO コライダー消す方がいいかも
        if (isOpen)
        {
            Debug.Log("s");
            // アイテムCubeを持っているかどうか
            bool Clear = ItemBox.instance.TryUseItem(clearItem);
            if(Clear == true) // クリアアイテムを持っている場合
            {
                Debug.Log("ギミック解除");
                gameObject.SetActive(false);    // TODO:蓋が開くアニメーションを追加 
            }
            else
            {
                Debug.Log("開かないみたいだ");
            }
        }
    }
    
    public void OnClickCode()
    {
        clickColider = null;
 
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
 
        if (Physics.Raycast(ray, out hit)) {
            clickColider = hit.collider;
        }

        for (int i = 0; i < codesColiderList.Count; i++)
        {
            if (clickColider == codesColiderList[i])
            {
                SwitchOnOff(i);
            }
        }
    }

    void SwitchOnOff(int position)
    {
        if (offCodesList[position].activeSelf == true)
        {
            onCodesList[position].SetActive(true);
            offCodesList[position].SetActive(false);
        }
        else
        {
            onCodesList[position].SetActive(false);
            offCodesList[position].SetActive(true);
        }
    }
    
}
