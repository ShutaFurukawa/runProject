using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSell : MonoBehaviour
{
    [SerializeField]
    private GameObject product;

    [SerializeField]
    private GameObject selector;

    private int selectNo;
    private Vector3 moveX = new Vector3(0.35f, 0, 0);

    private bool actv;

    // Start is called before the first frame update
    void Start()
    {
        selectNo = 0;
        //actv = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (actv)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (selectNo != 2 && selectNo != 4)
                {
                    selector.transform.localPosition += moveX;
                    selectNo++;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (selectNo != 0 && selectNo != 3)
                {
                    selector.transform.localPosition -= moveX;
                    selectNo--;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectNo == 0)
                {
                    Vector3 moveY = new Vector3(0.175f, -0.60f, 0);
                    selector.transform.localPosition += moveY;
                    selectNo = 3;
                }
                else if (selectNo == 1)
                {
                    Vector3 moveY = new Vector3(0.175f, 0.60f, 0);
                    selector.transform.localPosition -= moveY;
                    selectNo = 3;
                }
                if (selectNo == 2)
                {
                    Vector3 moveY = new Vector3(0.175f, 0.60f, 0);
                    selector.transform.localPosition -= moveY;
                    selectNo = 4;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectNo == 3)
                {
                    Vector3 moveY = new Vector3(0.175f, 0.60f, 0);
                    selector.transform.localPosition += moveY;
                    selectNo = 1;
                }
                else if (selectNo == 4)
                {
                    Vector3 moveY = new Vector3(0.175f, 0.60f, 0);
                    selector.transform.localPosition += moveY;
                    selectNo = 2;
                }
            }
        }
    }

    public void ActiveProduct(bool act)
    {
        product.SetActive(act);
        actv = act;
    }
}
