using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuy : MonoBehaviour
{
    [SerializeField]
    private GameObject product;

    [SerializeField]
    private GameObject selector;

    private int selectNoX;
    private int selectNoY;
    private Vector3 moveX = new Vector3(0.25f, 0, 0);
    private Vector3 moveY = new Vector3(0, 0.60f, 0);

    private bool actv;

    // Start is called before the first frame update
    void Start()
    {
        selectNoX = 0;
        selectNoY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(actv)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (selectNoX != 4)
                {
                    selector.transform.localPosition += moveX;
                    selectNoX++;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (selectNoX != 0)
                {
                    selector.transform.localPosition -= moveX;
                    selectNoX--;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectNoY != 1)
                {
                    selector.transform.localPosition -= moveY;
                    selectNoY++;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectNoY != 0)
                {
                    selector.transform.localPosition += moveY;
                    selectNoY--;
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
