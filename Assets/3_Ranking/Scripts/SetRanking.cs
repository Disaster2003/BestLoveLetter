using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    private Text txtRank;
    private int[] rank = new int[6]; // ��ƃG���A

    // Start is called before the first frame update
    void Start()
    {
        txtRank = GetComponent<Text>();
        txtRank.text = "";

        // �����L���O
        InitializeRankArray();
        Ranking();
    }

    /// <summary>
    /// rank�̏�����
    /// </summary>
    private void InitializeRankArray()
    {
        // �A�v���̃f�[�^�̈悪���݂��邩
        if (PlayerPrefs.HasKey("R1"))
        {
            for (int idx = 1; idx <= 5; idx++)
            {
                // �f�[�^�̈�ǂݍ���
                rank[idx] = PlayerPrefs.GetInt("R" + idx);
            }

            Debug.Log("�f�[�^�̈��ǂݍ��݂܂����B");
        }
        else
        {
            for (int idx = 1; idx <= 5; idx++)
            {
                rank[idx] = 0; // �[���ŏ�����
                PlayerPrefs.SetInt("R" + idx, rank[idx]); // �[�����i�[����
            }

            Debug.Log("�f�[�^�̈�����������܂����B");
        }
    }

    /// <summary>
    /// �����L���O����
    /// </summary>
    private void Ranking()
    {
        Debug.Log(gameObject.name);
        int ELAPSED = PlayerPrefs.GetInt("R6");
        int newRank = 0; // �܂�����̃X�R�A��0�ʂƉ��肷��

        for (int idx = 5; idx > 0; idx--)
        {
            // �t�� 5...1
            if (rank[idx] < ELAPSED)
            {
                newRank = idx; // �V���������N�Ƃ��Ĕ��肷��
            }
        }

        // 0�ʂ̂܂܂łȂ������烉���N�C���m��
        if (newRank != 0)
        {
            for (int idx = 5; idx > newRank; idx--)
            {
                // �J�艺������
                rank[idx] = rank[idx - 1];
            }
            rank[newRank] = ELAPSED;    // �V�����N�ɓo�^

            for (int idx = 1; idx <= 5; idx++)
            {
                // �f�[�^�̈�ɕۑ�
                PlayerPrefs.SetInt("R" + idx, rank[idx]);
            }
        }

        // ���ꂼ��̃����N�̒l��ݒ肷��
        for (int idx = 1; idx <= 5; idx++)
        {
            txtRank.text += idx +  "." + rank[idx].ToString();  // �����N����
            txtRank.text += System.Environment.NewLine;         // ���s���������Ă���
        }
    }
}
