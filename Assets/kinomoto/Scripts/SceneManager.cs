using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManager
{
    public static void TitleLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    public static void GameLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public static void GameOverLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
