using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmick : MonoBehaviour
{
    //�M�~�b�N����������A�C�e�����O�Őݒ�ł���悤�ɂ���
    [SerializeField] Item.Type clearItem = default;

    public void OnClickObj()
    {
        Debug.Log("s");
        // �A�C�e��Cube�������Ă��邩�ǂ���
        bool Clear = ItemBox.instance.TryUseItem(clearItem);
        if(Clear == true) // �N���A�A�C�e���������Ă���ꍇ
        {
            Debug.Log("�M�~�b�N����");
            gameObject.SetActive(false);
        }
    }
}
