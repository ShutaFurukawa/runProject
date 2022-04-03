using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameDirector gameDir;
    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private SpriteRenderer image;
    [SerializeField]
    private Image hpBer;

    private float hpMax;
    private float hp;
    private float hpNow;

    private int money;

    private float under;

    // Start is called before the first frame update
    void Start()
    {
        hpMax = 250;
        hp = hpMax;
        hpNow = 1;

        money = 1000;

        under = image.bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            //ゲームオーバー
            gameDir.GameOver();
        }

        //Debug.Log(hp);
    }

    //当たり判定に居るとき
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Sun")
        {
            //ダメージ
            Damage(gameDir.Damage);
            slideBar();
        }

        if(collision.tag == "Ground")
        {
            //接地判定
            controller.SetIsGround = true;
        }
    }

    //当たり判定に当たったとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            //接地判定
            controller.SetIsGround = true;
            controller.SetCollider = collision;
        }

        if (collision.tag == "Roof")
        {

            if ((transform.position.y - under) > collision.transform.position.y)
            {
                controller.SetCollider = collision;
                controller.SetIsGround = true;
            }
        }
    }

    //当たり判定から離れたとき
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground" || collision.tag == "Roof")
        {
            controller.SetCollider = null;
            controller.SetIsGround = false;
        }
    }

    //ダメージメソッド
    private void Damage(float damage)
    {
        if(hp > 0)
        {
            hp -= damage;
        }
    }

    //hpバー管理
    private void slideBar()
    {
        hpNow = hp / hpMax;
        hpBer.fillAmount = hpNow;
    }
}
