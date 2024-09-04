using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// シーンの状態
    /// </summary>
    private enum SCENE_STATE
    {
        TITLE = 0,
        EXPLAIN = 1,
        PLAY = 2,
        RANKING,
    }

    /// <summary>
    /// クリックしたら、シーン遷移
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
