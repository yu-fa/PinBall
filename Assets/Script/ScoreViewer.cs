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

    /* 定数 */
    private const int smallStarTagPoint = 10;
    private const int largeStarTag = 20;
    private const int smallCloudTag = 15;
    private const int largeCloudTag = 50;

    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        TotalScoreText.text = "Score：0";
    }

    // Update is called once per frame
    void Update()
    {

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
            this.TotalScore += smallStarTagPoint;
            ViewScore(this.TotalScore);
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.TotalScore += largeStarTag;
            ViewScore(this.TotalScore);
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.TotalScore += smallCloudTag;
            ViewScore(this.TotalScore);
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.TotalScore += largeCloudTag;
            ViewScore(this.TotalScore);
        }

    }

    //scoreを表示
    void ViewScore(int TotalScore)
    {
        //得点（Score）を常に表示（更新）
        this.TotalScoreText.text = "Score:" + TotalScore.ToString();
    }
}
