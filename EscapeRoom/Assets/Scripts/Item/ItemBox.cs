using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots = default;
    [SerializeField] Slot selectedSlot = null;

    [SerializeField] ZoomCanvas zoomCanvas = default;
    
    // �ǂ��ł����s�ł�����
    public static ItemBox instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            slots = GetComponentsInChildren<Slot>();
        }
    }

    // PickupObj���N���b�N���ꂽ��A�X���b�g�ɃA�C�e���������
    public void SetItem(Item item)
    {
        foreach(Slot slot in slots) // slots�̐������J��Ԃ�
        {
            if (slot.IsEmpty()) //slot�������󂾂����ꍇ
            {
                slot.SetItem(item); //slot�ɃA�C�e��������
                break;              //��̃X���b�g�ɃA�C�e������ꂽ��J��Ԃ����~�߂�
            }
        }
    }

    //�X���b�g���I�����ꂽ���Ɏ��s����֐�
    public void OnSelectSlot(int position)
    {
        //��U�S�ẴX���b�g�̑I���p�l�����\���ɂ���
        foreach(Slot slot in slots) //slots�̐������J��Ԃ�
        {
            slot.HideBGPanel();
        }

        //�I���A�C�e��������Ƀ^�b�v�Ŋg��\��������
        if (selectedSlot == slots[position])
        {
            zoomCanvas.ShowPanel();
        }
        selectedSlot = null;

        //�I�����ꂽ�X���b�g�̑I���p�l����\��
        if (slots[position].OnSelected())
        {
            selectedSlot = slots[position];

        }
    }

    //�A�C�e���̎g�p�����݂違�g����Ȃ�g���Ă��܂�
    public bool TryUseItem(Item.Type type)
    {
        //�I���X���b�g�����邩�ǂ���
        if(selectedSlot == null)
        {
            return false;
        }

        if(selectedSlot.GetItem().type == type)
        {
            selectedSlot.SetItem(null); // �g�����A�C�e��������
            selectedSlot.HideBGPanel(); // �I��w�i�摜������
            selectedSlot = null;        // �I��ł�X���b�g�̕ێ����Ȃ���
            return true;
        }
        return false;
    }

    public Item GetSelectedItem()
    {
        if (selectedSlot == null)
        {
            return null;
        }
        return selectedSlot.GetItem();
    }
}
