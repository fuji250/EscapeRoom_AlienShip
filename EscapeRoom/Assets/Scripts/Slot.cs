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
        //image = GetComponent<Image>(); //imageにImageコンポーネントを入れる
    }

    private void Start()
    {
        backgroundPanel.SetActive(false);
    }

    //空かどうかの判断をする関数
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

    //ItemBoxスクリプトのTryUseItem関数で実行
    public Item GetItem()
    {
        return item;
    }

    // アイテムを受け取ったら画像をスロットに表示してやる
    void UpdateImage(Item item)
    {
        if(item == null) //もしアイテムがないなら
        {
            image.sprite = null; //画像を何も入れない
        }
        else
        {
            image.sprite = item.sprite;　//Slotのimageにクリックしたアイテムのspriteを入れる
        }
    }

    //選択した時の背景パネルを表示する関数　＝＞ItemBoxスクリプトのOnSelectSlot関数で使用
    public bool OnSelected()
    {
        if (item == null)
        {
            return false;
        }
        backgroundPanel.SetActive(true); //背景画像パネルを表示する
        return true;
    }

    public void HideBGPanel()
    {
        backgroundPanel.SetActive(false); //背景画像パネルを非表示にする
    }
}