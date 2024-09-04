using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GetComponent<Text>().text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score : " + score.ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("R6", score); // ÉXÉRÉAÇäiî[Ç∑ÇÈ
    }
}
