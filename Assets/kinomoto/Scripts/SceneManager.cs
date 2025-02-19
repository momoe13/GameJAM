using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager
{
    public void TitleLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    public void GameLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void GameOverLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
