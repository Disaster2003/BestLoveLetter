using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    private Text txtRank;
    private int[] rank = new int[6]; // 作業エリア

    // Start is called before the first frame update
    void Start()
    {
        txtRank = GetComponent<Text>();
        txtRank.text = "";

        // ランキング
        InitializeRankArray();
        Ranking();
    }

    /// <summary>
    /// rankの初期化
    /// </summary>
    private void InitializeRankArray()
    {
        // アプリのデータ領域が存在するか
        if (PlayerPrefs.HasKey("R1"))
        {
            for (int idx = 1; idx <= 5; idx++)
            {
                // データ領域読み込み
                rank[idx] = PlayerPrefs.GetInt("R" + idx);
            }

            Debug.Log("データ領域を読み込みました。");
        }
        else
        {
            for (int idx = 1; idx <= 5; idx++)
            {
                rank[idx] = 0; // ゼロで初期化
                PlayerPrefs.SetInt("R" + idx, rank[idx]); // ゼロを格納する
            }

            Debug.Log("データ領域を初期化しました。");
        }
    }

    /// <summary>
    /// ランキング処理
    /// </summary>
    private void Ranking()
    {
        Debug.Log(gameObject.name);
        int ELAPSED = PlayerPrefs.GetInt("R6");
        int newRank = 0; // まず今回のスコアを0位と仮定する

        for (int idx = 5; idx > 0; idx--)
        {
            // 逆順 5...1
            if (rank[idx] < ELAPSED)
            {
                newRank = idx; // 新しいランクとして判定する
            }
        }

        // 0位のままでなかったらランクイン確定
        if (newRank != 0)
        {
            for (int idx = 5; idx > newRank; idx--)
            {
                // 繰り下げ処理
                rank[idx] = rank[idx - 1];
            }
            rank[newRank] = ELAPSED;    // 新ランクに登録

            for (int idx = 1; idx <= 5; idx++)
            {
                // データ領域に保存
                PlayerPrefs.SetInt("R" + idx, rank[idx]);
            }
        }

        // それぞれのランクの値を設定する
        for (int idx = 1; idx <= 5; idx++)
        {
            txtRank.text += idx +  "." + rank[idx].ToString();  // ランク文字
            txtRank.text += System.Environment.NewLine;         // 改行文字をつけている
        }
    }
}
