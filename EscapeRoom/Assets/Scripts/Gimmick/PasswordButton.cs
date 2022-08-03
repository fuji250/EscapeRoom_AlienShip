using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PasswordButton : MonoBehaviour
{
    [SerializeField] TMP_Text numberText = default;
    public int number;

    private void Start()
    {
        number = 0;
        numberText.text = number.ToString(); //�e�L�X�g�̐��l��ς���
    }


    // ���s���ꂽ�琔�l��ς���
    public void OnClickThis()
    {
        number++; // ���l���{�P����
        if(number > 9) // �����X�𒴂�����
        {
            number = 0; // 0�ɖ߂�
        }
        numberText.text = number.ToString(); //�e�L�X�g�̐��l��ς���

    }
}