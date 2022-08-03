using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item = null;
    [SerializeField] Image image = default;
    [SerializeField] GameObject backgroundPanel = default;

    private void Awake()
    {
        //image = GetComponent<Image>(); //image��Image�R���|�[�l���g������
    }

    private void Start()
    {
        backgroundPanel.SetActive(false);
    }

    //�󂩂ǂ����̔��f������֐�
    public bool IsEmpty()
    {
        if(item == null)
        {
            return true;
        }
        return false;
    }
    public void SetItem(Item item)
    {
        this.item = item;
        UpdateImage(item);
    }

    //ItemBox�X�N���v�g��TryUseItem�֐��Ŏ��s
    public Item GetItem()
    {
        return item;
    }

    // �A�C�e�����󂯎������摜���X���b�g�ɕ\�����Ă��
    void UpdateImage(Item item)
    {
        if(item == null) //�����A�C�e�����Ȃ��Ȃ�
        {
            image.sprite = null; //�摜����������Ȃ�
        }
        else
        {
            image.sprite = item.sprite;�@//Slot��image�ɃN���b�N�����A�C�e����sprite������
        }
    }

    //�I���������̔w�i�p�l����\������֐��@����ItemBox�X�N���v�g��OnSelectSlot�֐��Ŏg�p
    public bool OnSelected()
    {
        if (item == null)
        {
            return false;
        }
        backgroundPanel.SetActive(true); //�w�i�摜�p�l����\������
        return true;
    }

    public void HideBGPanel()
    {
        backgroundPanel.SetActive(false); //�w�i�摜�p�l�����\���ɂ���
    }
}