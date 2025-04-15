using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private GameObject helpUI;

    public void ToggleHelpUI()
    {
        AudioManager.Instance.SelectSEPlay();
        if (helpUI.activeSelf)
        {
            helpUI.SetActive(false);
        }
        else
        {
            helpUI.SetActive(true);
        }
    }
}
