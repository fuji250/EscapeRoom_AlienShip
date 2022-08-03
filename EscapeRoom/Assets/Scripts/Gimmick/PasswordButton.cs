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
        numberText.text = number.ToString(); //テキストの数値を変える
    }


    // 実行されたら数値を変える
    public void OnClickThis()
    {
        number++; // 数値を＋１する
        if(number > 9) // もし９を超えたら
        {
            number = 0; // 0に戻す
        }
        numberText.text = number.ToString(); //テキストの数値を変える

    }
}