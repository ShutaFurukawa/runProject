using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopDirector : MonoBehaviour
{
    [SerializeField]
    private Image selector;
    [SerializeField]
    private int selectMin;
    [SerializeField]
    private int selectMax;

    [SerializeField]
    private ShopBuy buy;
    [SerializeField]
    private ShopSell sell;

    private string nextScene;

    private Vector3 move = new Vector3(0, 65.0f, 0);
    private RectTransform rect;

    private int selectNo;
    private bool selectFlg;

    // Start is called before the first frame update
    void Start()
    {
        nextScene = "Main";
        //uGUIを触るときはRectTranceformじゃないとダメ
        rect = selector.GetComponent<RectTransform>();

        selectNo = 0;
        selectFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(nextScene);
        }

        if (!selectFlg)
        {
            if (selectNo != selectMax)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rect.localPosition -= move;
                    selectNo++;
                }
            }

            if (selectNo != selectMin)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rect.localPosition += move;
                    selectNo--;
                }
            }
        }

        //Zで決定
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (!selectFlg)
            {
                if (selectNo == 0)
                {
                    buy.ActiveProduct(true);
                }
                else if (selectNo == 1)
                {
                    sell.ActiveProduct(true);
                }
                else if(selectNo == 2)
                {
                    Debug.Log("所持アイテム表示");
                }
            }
            selectFlg = true;
        }

        //Xでキャンセル
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(selectFlg)
            {
                selectFlg = false;
                buy.ActiveProduct(false);
                sell.ActiveProduct(false);
            }
        }
    }
}
