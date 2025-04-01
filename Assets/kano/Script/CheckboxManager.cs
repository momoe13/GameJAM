using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager : MonoBehaviour
{
    [SerializeField]
    Toggle tabToggle;

    [SerializeField]
    Camera mainCamera;
    //Toggleの値が変更されたときに呼び出される
    public void ChackToggle()
    {
        //左側にタブ追加
        if (tabToggle.isOn)
        {
            mainCamera.orthographicSize = 7;
        }
        //スコアタブ消す
        else 
        {
            mainCamera.orthographicSize = 5;
        }

    }

    public bool GetCheck()
    {
        return tabToggle.isOn;
    }
}
