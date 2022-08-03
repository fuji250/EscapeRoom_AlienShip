using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObj : MonoBehaviour
{
    [SerializeField] GameObject setObject;
    [SerializeField] Item.Type useItem;

    public void OnClickThis()
    {
        //適切なアイテムを選択した状態で
        bool hasItem = ItemBox.instance.TryUseItem(useItem);
        if (hasItem)
        {
        setObject.SetActive(true);

        }
    }
}
