using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    //アイテムIDリスト
    private List<int> itemList = new List<int>()
    {
        101,
        102,
        103
    };


    public int GetItemData(int id)
    {
        return itemList[id];
    }
}
