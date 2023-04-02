using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Password : MonoBehaviour
{
    // ��������ƁA�O���̊֐������s����(UnityEvent)
    public UnityEvent ClearEvent;

    public Button[] passwordButtons;

    int[] currentNum = { 0, 0, 0 };//�}�`�̐���1,1,1
    int[] correctAnserNum = { 2, 2, 1 };//�}�`�̐���3,3,2

    public SpriteRenderer[] Sprites;

    //�摜
    public Sprite[] TriangleResourceSpr;
    public Sprite[] CircleResourceSpr;
    public Sprite[] SquareResourceSpr;


    public void OnMarkButton(int position)
    {
        // �}�[�N��ύX����
        ChangeMark(position);
        
        if (IsClear() == true)
        {
            Clear();
        }
    }

    void ChangeMark(int position)
    {
        currentNum[position]++; // �P���̃}�[�N
        if (currentNum[position] > 2)
        {
            currentNum[position] = 0;
        }
        
        //TODO �������G�ȏ����ɂȂ��Ă邯�ǂ��ꂼ��̉摜�̃��X�g�̉��Ԗڂ��ǂ��ŋL���̐����擾���Ă��ꂪ�R�ȏ�ɂȂ�����O�ɖ߂��Ƃ��ŃX�b�L���ł��邩��
        int index = currentNum[position]; // int��
        if (position == 0)
        {
            Sprites[position].sprite = TriangleResourceSpr[index]; // �Ή�����摜��\��
            //���l���͈͓��ɂȂ�悤�ɒ���
            if (index == 0)
            {
                index = 3;
            }
            Sprites[position+3].sprite = CircleResourceSpr[index-1];
        }
        else if (position == 1)
        {
            Sprites[position].sprite = CircleResourceSpr[index]; // �Ή�����摜��\��
            //���l���͈͓��ɂȂ�悤�ɒ���
            if (index == 2)
            {
                index = -1;
            }
            Sprites[position+3].sprite = SquareResourceSpr[index+1];
        }
        else if (position == 2)
        {
            Sprites[position].sprite = SquareResourceSpr[index];
            Sprites[position+3].sprite = TriangleResourceSpr[index];
        }
    }


    //�N���A�������Ɏ��s����֐�
    public void Clear()
    {
        Debug.Log("�N���A");
        ClearEvent.Invoke();

        Destroy(this);
    }

    //�N���A���Ă��邩���肷��֐�
    bool IsClear()
    {
        // �������Ă��邩�ǂ���
        // =>�P�ł���v���Ȃ����false
        // =>�S�Ẵ`�F�b�N���N���A�����true
        for (int i = 0; i < correctAnserNum.Length; i++)
        {
            if (currentNum[i] != correctAnserNum[i])
            {
                return false;
            }
        }
        return true;
    }
}