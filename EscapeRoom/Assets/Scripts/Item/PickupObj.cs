using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type itemType = default; //default������ƌx�����o�Ȃ��Ȃ�
    Item item = default;


    private void Start()
    {
        //itemType�ɉ�����item�𐶐�����(�A�C�e���ɑ΂���Type��Sprite��ݒ肷��j
        item = ItemGenerater.instance.Spawn(itemType);
    }

    //�N���b�N���������
    public void OnClickObj()
    {
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
    }
}