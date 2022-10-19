using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Password : MonoBehaviour
{
    // 正解すると、外部の関数を実行する(UnityEvent)
    public UnityEvent ClearEvent;

    public Button[] passwordButtons;

    int[] currentNum = { 0, 0, 0 };//図形の数は1,1,1
    int[] correctAnserNum = { 2, 2, 1 };//図形の数は3,3,2

    public SpriteRenderer[] Sprites;

    //画像
    public Sprite[] TriangleResourceSpr;
    public Sprite[] CircleResourceSpr;
    public Sprite[] SquareResourceSpr;


    public void OnMarkButton(int position)
    {
        // positionのマークを変更する
        ChangeMark(position);
        // positionの画像を表示する
        ShowMark(position);
        if (IsClear() == true)
        {
            Clear();
        }
    }

    void ChangeMark(int position)
    {
        currentNum[position]++; // １つ次のマーク
        if (currentNum[position] > 2)
        {
            currentNum[position] = 0;
        }
    }

    void ShowMark(int position)
    {
        int index = currentNum[position]; // int化
        if (position == 0)
        {
            Sprites[position].sprite = TriangleResourceSpr[index]; // 対応する画像を表示
            //数値が範囲内になるように調整
            if (index == 0)
            {
                index = 3;
            }
            Sprites[position+3].sprite = CircleResourceSpr[index-1];
        }
        else if (position == 1)
        {
            Sprites[position].sprite = CircleResourceSpr[index]; // 対応する画像を表示
            //数値が範囲内になるように調整
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

    //クリアした時に実行する関数
    public void Clear()
    {
        Debug.Log("クリア");
        Destroy(this);
        ClearEvent.Invoke();
    }

    //クリアしているか判定する関数
    bool IsClear()
    {
        // 正解しているかどうか
        // =>１つでも一致しなければfalse
        // =>全てのチェックをクリアすればtrue
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