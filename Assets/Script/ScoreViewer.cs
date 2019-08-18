using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{

    //スコアの合計値を格納
    private int TotalScore = 0;

    //スコアの合計値の文字列
    public Text TotalScoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        TotalScoreText.text = "Score：0";
    }

    // Update is called once per frame
    void Update()
    {

        //得点（Score）を常に表示（更新）
        TotalScoreText.text = "Score:" + TotalScore.ToString();

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // TotalScoreの計算
        /* ==========================================
            *Tagを分岐条件に点数をTotaScoreへ加算
            *  Tag = SmallStarTag の場合 10点
            *  Tag = LargeStarTag の場合 20点
            *  Tag = SmallCloudTag の場合 15点
            *  Tag = LargeCloudTag の場合 50点
          ============================================ */
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.TotalScore += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.TotalScore += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.TotalScore += 15;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.TotalScore += 50;
        }

    }
}
