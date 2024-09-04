using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���̏��
    /// </summary>
    private enum SCENE_STATE
    {
        TITLE = 0,
        EXPLAIN = 1,
        PLAY = 2,
        RANKING,
    }

    /// <summary>
    /// �N���b�N������A�V�[���J��
    /// </summary>
    public void OnClickNextScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex == (int)SCENE_STATE.RANKING)
            SceneManager.LoadSceneAsync(0);
        else
            SceneManager.LoadSceneAsync(buildIndex + 1);
    }
}
