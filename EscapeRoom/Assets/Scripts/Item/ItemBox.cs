using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots = default;
    [SerializeField] Slot selectedSlot = null;

    [SerializeField] ZoomCanvas zoomCanvas = default;
    
    // どこでも実行できるやつ
    public static ItemBox instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            slots = GetComponentsInChildren<Slot>();
        }
    }

    // PickupObjがクリックされたら、スロットにアイテムをいれる
    public void SetItem(Item item)
    {
        foreach(Slot slot in slots) // slotsの数だけ繰り返す
        {
            if (slot.IsEmpty()) //slotがもし空だった場合
            {
                slot.SetItem(item); //slotにアイテムを入れる
                break;              //空のスロットにアイテムを入れたら繰り返しを止める
            }
        }
    }

    //スロットが選択された時に実行する関数
    public void OnSelectSlot(int position)
    {
        //一旦全てのスロットの選択パネルを非表示にする
        foreach(Slot slot in slots) //slotsの数だけ繰り返す
        {
            slot.HideBGPanel();
        }

        //選択アイテムをさらにタップで拡大表示させる
        if (selectedSlot == slots[position])
        {
            zoomCanvas.ShowPanel();
        }
        selectedSlot = null;

        //選択されたスロットの選択パネルを表示
        if (slots[position].OnSelected())
        {
            selectedSlot = slots[position];

        }
    }

    //アイテムの使用を試みる＆使えるなら使ってしまう
    public bool TryUseItem(Item.Type type)
    {
        //選択スロットがあるかどうか
        if(selectedSlot == null)
        {
            return false;
        }

        if(selectedSlot.GetItem().type == type)
        {
            selectedSlot.SetItem(null); // 使ったアイテムを消す
            selectedSlot.HideBGPanel(); // 選択背景画像も消す
            selectedSlot = null;        // 選んでるスロットの保持もなくす
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
