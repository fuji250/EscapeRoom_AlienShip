using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObj : MonoBehaviour
{
    [SerializeField] GameObject setObject;
    [SerializeField] Item.Type useItem;

    public void OnClickThis()
    {
        //�K�؂ȃA�C�e����I��������Ԃ�
        bool hasItem = ItemBox.instance.TryUseItem(useItem);
        if (hasItem)
        {
        setObject.SetActive(true);

        }
    }
}
