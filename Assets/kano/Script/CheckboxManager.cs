using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager : MonoBehaviour
{
    [SerializeField]
    Toggle tabToggle;


    [SerializeField]
    GameObject Box;
    //Toggleの値が変更されたときに呼び出される
    public void ChackToggle()
    {
        //左側にタブ追加
        if (tabToggle.isOn)
        {
            Box.transform.localScale = new Vector3(100f,100f, 0);
            Box.transform.localPosition = new Vector3(-11,75, 0);    
        }
        //スコアタブ消す
        else 
        { 
            Box.transform.localScale = new Vector3(108.4f,108.4f,0);
            Box.transform.localPosition = new Vector3(-261, 78, 0);
        }

    }

    public bool GetCheck()
    {
        return tabToggle.isOn;
    }
}
