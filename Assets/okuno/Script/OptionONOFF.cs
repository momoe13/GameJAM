using UnityEngine;

public class OptionONOFF : MonoBehaviour
{
    public static OptionONOFF Instance {  get; private set; }
    [SerializeField] private GameObject optionUi;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            IsPlaying.isPlay = false;
            optionUi.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            IsPlaying.isPlay = true;
            optionUi.SetActive(false);
        }
    }
}
