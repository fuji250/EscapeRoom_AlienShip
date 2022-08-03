using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmick : MonoBehaviour
{
    //ギミックを解除するアイテムを外で設定できるようにする
    [SerializeField] Item.Type clearItem = default;

    public void OnClickObj()
    {
        Debug.Log("s");
        // アイテムCubeを持っているかどうか
        bool Clear = ItemBox.instance.TryUseItem(clearItem);
        if(Clear == true) // クリアアイテムを持っている場合
        {
            Debug.Log("ギミック解除");
            gameObject.SetActive(false);
        }
    }
}
