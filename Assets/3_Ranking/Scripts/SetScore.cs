using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �^�C���A�b�v���̃X�R�A��ݒ肷��
        GetComponent<Text>().text = "Score : " + PlayerPrefs.GetInt("R6").ToString();
    }
}
