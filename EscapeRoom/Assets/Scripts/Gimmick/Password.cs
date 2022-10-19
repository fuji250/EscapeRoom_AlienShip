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
        // position�̃}�[�N��ύX����
        ChangeMark(position);
        // position�̉摜��\������
        ShowMark(position);
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
    }

    void ShowMark(int position)
    {
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

        Debug.Log(currentNum);
    }

    //�N���A�������Ɏ��s����֐�
    public void Clear()
    {
        Debug.Log("�N���A");
        Destroy(this);
        ClearEvent.Invoke();
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