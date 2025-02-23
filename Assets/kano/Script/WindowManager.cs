using UnityEngine;

public class Window : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            Screen.SetResolution(1768, 992, false);
        }
    }
}
