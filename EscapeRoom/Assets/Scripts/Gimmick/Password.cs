using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Password : MonoBehaviour
{
    // 正解すると、外部の関数を実行する(UnityEvent)
    public UnityEvent ClearEvent;

    // 正解の数値
    [SerializeField] int[] correctNumbers = default;

    //現在の数値:PasswardButtonのNumberを見ればいい
    [SerializeField] PasswordButton[] passwardButtons = default;

    // クリックするたびに現在のパネルの数値と正解を比較
    // 一致するならクリアログ


    //クリアした時に実行する関数
    public void CheckClear()
    {
        if(IsClear() == true)
        {
            Debug.Log("クリア");
            ClearEvent.Invoke();
        }
    }


    //クリアしているか判定する関数
    bool IsClear()
    {
        // 正解しているかどうか
        // =>１つでも一致しなければfalse
        // =>全てのチェックをクリアすればtrue

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