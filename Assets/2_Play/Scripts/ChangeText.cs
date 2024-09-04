using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    // ���_�Ǝ莆��
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

        // CSV�̓ǂݍ���
        TextAsset csvFile = Resources.Load("PointAndMessageData") as TextAsset; // Resources�ɂ���CSV�t�@�C�����i�[
        StringReader reader = new StringReader(csvFile.text); // TextAsset��StringReader�ɕϊ�
        List<string[]> csvData = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1�s���ǂݍ���
            csvData.Add(line.Split(','));    // csvData���X�g�ɒǉ�����
        }

        // CSV�̒l��ݒ�
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
        // ���̕��͂�
        if (isChangedText)
        {
            isChangedText = false;

            // ���_�Ǝ莆����ݒ肷��
            int tmp = Random.Range(0, point_and_message.Count);
            point = point_and_message[tmp].point;
            GetComponent<Text>().text = 
                point_and_message[tmp].message;

            // ���̃t�H���g��ݒ肷��
            if (tmp < point_and_message.Count / 2)
                GetComponent<Text>().font = fontLetter[0];
            else
                GetComponent<Text>().font = fontLetter[1];
        }
    }
}
