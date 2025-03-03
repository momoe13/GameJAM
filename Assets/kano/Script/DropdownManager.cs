using UnityEngine;
using UnityEngine.UI;

public class DropdownManager : MonoBehaviour
{
    private Dropdown dropdown;
    public void ChangeWindow()
    {
        switch (dropdown.value)
        {
            case 0:
                Screen.SetResolution(640,480, false);
                break;
            case 1:
                Screen.SetResolution(800, 600, false);
                break;
            case 2:
                Screen.SetResolution(1024,768, false);
                break;
            case 3:
                Screen.SetResolution(1280,960, false);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, false);
                break;
        }
            

    }
}