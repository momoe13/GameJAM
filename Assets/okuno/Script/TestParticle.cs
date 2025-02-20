using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestParticle : MonoBehaviour
{
    enum State
    {
        TITLE = 0,
        GAMESCENE,
        RESULT,
    };

    [SerializeField] private GameObject particleParent;
    [SerializeField] private GameObject fadeIn;
    [SerializeField] private GameObject fadeOut;
    private State state = 0;

    private void Start()
    {
        DontDestroyOnLoad(particleParent);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(fade());
        }
    }

    public void fadeCall()
    {
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        fadeOut.SetActive(true);
        if ((int)state == 0)
        {
            SceneManager.GameLordScene();
        }
        else if((int)state == 1)
        {
            SceneManager.GameOverLordScene();
        }
        else if((int)state == 2)
        {
            SceneManager.TitleLordScene();
        }
        if ((int)state <= 2)
        {
            state++;
        }
        else
        {
            state = 0;
        }
        yield return new WaitForSeconds(2.0f);
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
    }
}
