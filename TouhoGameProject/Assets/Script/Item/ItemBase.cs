using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//itemの元となる基底クラス
public class ItemBase : MonoBehaviour
{
    [SerializeField]
    private int id;

    //デリゲート(関数ポインタ)
    private System.Action effect;
    
    // Start is called before the first frame update
    void Start()
    {
        effect = null;
    }

    // Update is called once per frame
    void Update()
    {
        //ここでは特に何もしない
    }

    //アイテムの効果を渡す
    public System.Action UseItem()
    {
        //関数ポインタを渡す
        return effect;
    }
}
