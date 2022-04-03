using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//プレイヤーの操作を管理するクラス
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 3.0f;
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
    private float accceleration = 0.0f;

    private Vector3 initPos;

    private Vector3 gravityVal;
    private float jumpLimit = 4.0f;
    private float jumpUp = 0.0f;

    private float cd = 0.0f;

    private Collider2D collider = null;

    private bool isGravity = false;
    private bool isJump = false;
    private bool isGround = false;
    private bool isPlessed = false;

    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;

        gravityVal = new Vector3(0, gravity * Time.deltaTime, 0);
        jumpUp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプボタンを押しているなら
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJump && isGround && canJump && !isPlessed)
            {
                isJump = true;
                canJump = false;
                isPlessed = true;
            }
        }

        //ジャンプボタンを離したら
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJump = false;
            isPlessed = false;
        }

        if(isJump)
        {
            //キャラクターをジャンプさせる
            var junmVal = this.transform.up * jumpSpeed;
            this.transform.position += junmVal;
            jumpUp += jumpSpeed;
            isGround = false;
        }

        if(!isJump || jumpUp > jumpLimit)
        {
            if (!isGround && !collider)
            {
                //重力の影響を受けさせる
                isGravity = true;
                isJump = false;
            }
        }

        //重力反映
        if(isGravity && !isGround)
        {
            gravityVal.y += accceleration;
            this.transform.position -= gravityVal;
        }
        else if(isGround)
        {
            if(collider)
            {
                //足場の高さに自身を設定
                this.transform.position = new Vector3(
                    transform.position.x,
                    collider.transform.position.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2) + (collider.bounds.size.y / 2),
                    transform.position.z);
            }　
            else
            {
                this.transform.position = initPos;
            }

            gravityVal = new Vector3(0, gravity * Time.deltaTime, 0);
            isGravity = false;
            jumpUp = 0.0f;
        }

        //ジャンプにクールタイムを付与する
        if(isGround && !isJump)
        {
            if(!canJump)
            {
                cd++;
            }

            if(cd <= 10)
            {
                canJump = true;
                cd = 0;
            }
        }
    }

    public bool SetIsGround
    {
        set { isGround = value; }
    }

    public Collider2D SetCollider
    {
        set { collider = value; }
    }

}
