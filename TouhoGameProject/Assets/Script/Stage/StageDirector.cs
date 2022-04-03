using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージの管理を行うクラス
public class StageDirector : MonoBehaviour
{
    [SerializeField]
    private GameDirector gameDir;

    //ステージオブジェクト
    [SerializeField]
    private GameObject stageObject;
    [SerializeField]
    private GameObject fields;
    [SerializeField]
    private GameObject goal;
    [SerializeField]
    private GameObject suns;

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float accceleration = 0.0f;

    private float goalPoint;

    // Start is called before the first frame update
    void Start()
    {
        //初期設定
        stageObject.transform.position = Vector3.zero;

        goalPoint = -goal.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(stageObject.transform.position.x > goalPoint)
        {
            //ステージをスクロールさせる
            var moveal = new Vector3(-(speed * Time.deltaTime), 0, 0);
            stageObject.transform.position += moveal;
            fields.transform.position += moveal;
            suns.transform.position += moveal;
        }
        else if(stageObject.transform.position.x <= goalPoint)
        {
            //シーン遷移
            //gameDir.ChangeScene();
        }
    }
}
