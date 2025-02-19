using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManager
{
    public static void TitleLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("0_TitleScene");
    }

    public static void GameLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("1_InGameScene");
    }

    public static void GameOverLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
