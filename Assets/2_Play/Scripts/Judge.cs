using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    /// <summary>
    /// クリックしたら、スコアを加算
    /// </summary>
    public void OnClickPlusPoint()
    {
        ChangeText.isChangedText = true;
        Score.score += ChangeText.point;
    }

    /// <summary>
    /// クリックしたら、スコアを加算
    /// </summary>
    public void OnClickDestroy()
    {
        ChangeText.isChangedText = true;
    }
}
