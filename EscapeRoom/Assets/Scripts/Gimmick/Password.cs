using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Password : MonoBehaviour
{
    // ��������ƁA�O���̊֐������s����(UnityEvent)
    public UnityEvent ClearEvent;

    // �����̐��l
    [SerializeField] int[] correctNumbers = default;

    //���݂̐��l:PasswardButton��Number������΂���
    [SerializeField] PasswordButton[] passwardButtons = default;

    // �N���b�N���邽�тɌ��݂̃p�l���̐��l�Ɛ������r
    // ��v����Ȃ�N���A���O


    //�N���A�������Ɏ��s����֐�
    public void CheckClear()
    {
        if(IsClear() == true)
        {
            Debug.Log("�N���A");
            ClearEvent.Invoke();
        }
    }


    //�N���A���Ă��邩���肷��֐�
    bool IsClear()
    {
        // �������Ă��邩�ǂ���
        // =>�P�ł���v���Ȃ����false
        // =>�S�Ẵ`�F�b�N���N���A�����true

        for(int i=0; i<correctNumbers.Length; i++)
        {
            if (passwardButtons[i].number != correctNumbers[i])
            {
                return false;
            }
        }
        return true;
    }
}