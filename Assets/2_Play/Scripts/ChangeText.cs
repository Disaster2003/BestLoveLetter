using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    // 得点と手紙文
    private struct POINT_AND_MESSAGE
    {
        public int point;
        public string message;
    };
    private List<POINT_AND_MESSAGE> point_and_message = new List<POINT_AND_MESSAGE>();
    public static int point;
    public static bool isChangedText;

    [SerializeField] Font[] fontLetter;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "";
        isChangedText = true;

        // CSVの読み込み
        TextAsset csvFile = Resources.Load("PointAndMessageData") as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換
        List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(','));    // csvDataリストに追加する
        }

        // CSVの値を設定
        for (int i = 0; i < csvData.Count; i++)
        {
            POINT_AND_MESSAGE tmp;
            tmp.point = int.Parse(csvData[i][0]);
            tmp.message = csvData[i][1];
            point_and_message.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 次の文章へ
        if (isChangedText)
        {
            isChangedText = false;

            // 得点と手紙文を設定する
            int tmp = Random.Range(0, point_and_message.Count);
            point = point_and_message[tmp].point;
            GetComponent<Text>().text = 
                point_and_message[tmp].message;

            // 文のフォントを設定する
            if (tmp < point_and_message.Count / 2)
                GetComponent<Text>().font = fontLetter[0];
            else
                GetComponent<Text>().font = fontLetter[1];
        }
    }
}
