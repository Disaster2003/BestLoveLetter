using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // タイムアップ時のスコアを設定する
        GetComponent<Text>().text = "Score : " + PlayerPrefs.GetInt("R6").ToString();
    }
}
