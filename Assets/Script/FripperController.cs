using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // FingerId格納用
    private int leftFingerId;
    private int rightFingerId;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        // タッチの確認
        if (Input.touchCount > 0)
        {
            actionTouch();
        }
        else
        {
            actionArrow();
        }

    }

    void actionTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            // タッチ状況
            Touch touch = Input.GetTouch(i);

            //タッチすると行う何かをここに記入
            if (touch.phase == TouchPhase.Began)
            {
                // 左のフリッパーを動かす
                if (touch.position.x <= Screen.width * 0.5 && tag == "LeftFripperTag")
                {
                    this.leftFingerId = touch.fingerId;
                    SetAngle(this.flickAngle);
                }
                // 右のフリッパーを動かす
                if (touch.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
                {
                    this.rightFingerId = touch.fingerId;
                    SetAngle(this.flickAngle);
                }                
            }
             else if (touch.phase == TouchPhase.Ended)
            {
                // 左のフリッパーを戻す
                if (touch.fingerId == this.leftFingerId && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                // 右のフリッパーを戻す
                if (touch.fingerId == this.rightFingerId && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }

        }
    }

    void actionArrow()
    {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}