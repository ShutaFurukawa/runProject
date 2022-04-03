using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーが所持しているアイテムのクラス
public class PlayerItemContena
{
    public static List<int> itemIDs = new List<int>()
    {
        0,0,0
    };

    //リストに追加
    public void AddItem(int id)
    {
        itemIDs.Add(id);
    }

    //リストから削除
    public void DeleteItem(int id)
    {
        //リスト内にアイテムがあるなら
        if(itemIDs.Contains(id))
        {
            itemIDs.Remove(id);
        }
    }

    public static List<int> getList()
    {
        return itemIDs;
    }

}
