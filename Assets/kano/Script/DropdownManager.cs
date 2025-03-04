using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownManager : MonoBehaviour
{ 
    private TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }
    public void ChangeWindow()
    {
        switch (dropdown.value)
        {
            case 0:
                Screen.SetResolution(640, 480, false);
                Debug.Log("set0");
                break;
            case 1:
                Screen.SetResolution(800, 600, false);
                Debug.Log("set1");
                break;
            case 2:
                Screen.SetResolution(1024,768, false);
                Debug.Log("set2");
                break;
            case 3:
                Screen.SetResolution(1280,960, false);
                Debug.Log("set3");
                break;
            case 4:
                Screen.SetResolution(1920, 1080, false);
                Debug.Log("set4");
                break;
        }
            

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            //Screen.SetResolution(1768, 992, false);
            Screen.SetResolution(640, 480, false);
            Debug.Log("aaaa");
        }
    }
}