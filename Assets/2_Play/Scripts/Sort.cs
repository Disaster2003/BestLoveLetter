using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    /// <summary>
    /// �N���b�N������A�X�R�A�����Z
    /// </summary>
    public void OnClickPlusPoint()
    {
        ChangeText.isChangedText = true;
        Score.score += ChangeText.point;
    }
}
