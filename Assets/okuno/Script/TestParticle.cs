using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestParticle : MonoBehaviour
{
    public static TestParticle Instance { get; private set; }
    enum State
    {
        TITLE = 0,
        GAMESCENE,
        RESULT,
    };

    [SerializeField] private GameObject particleParent;
    [SerializeField] private ParticleSystem fadeIn;
    [SerializeField] private ParticleSystem fadeOut;
    private State state = 0;

    [SerializeField] private GameObject fadeManager;
    private bool isLoadScene = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("重複するTestParticleが破棄されました。");
            Destroy(gameObject); // 重複したインスタンスを破棄
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(particleParent);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "2_ResultScene" && !isLoadScene)
            {
                fadeCall();
                isLoadScene = true;
            }
        }
    }

    public void fadeCall()
    {
        StartCoroutine(fade());
        Debug.Log("FadeCallが呼ばれた");
    }

    private IEnumerator fade()
    {
        fadeIn.Play();
        yield return new WaitForSeconds(1.7f);
        fadeOut.Play();
        if (state == State.TITLE)
        {
            SceneManager.GameLordScene();
        }
        else if (state == State.GAMESCENE)
        {
            SceneManager.GameOverLordScene();
        }
        else if (state == State.RESULT)
        {
            SceneManager.TitleLordScene();
            isLoadScene = false;
        }
        state = state < State.RESULT ? state + 1 : State.TITLE;
        Debug.Log("今の状態" + state.ToString());
        yield return new WaitForSeconds(3.0f);
    }
}
