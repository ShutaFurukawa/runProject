using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーのアイテム使用を制御するスクリプト
public class PlayerItemCnt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムを使う
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("アイテム１を使用");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("アイテム２を使用");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("アイテム３を使用");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("アイテム４を使用");
        }
    }

    private void UseItem()
    {
        Debug.Log("アイテムを使うぜ");
    }
}
