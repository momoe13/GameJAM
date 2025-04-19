using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //private void Start()
    //{
    //    GameObject bm = GameObject.Find("ButtonManager");
    //    if (bm != null)
    //    {
    //        ButtonAction buttonAction = bm.GetComponent<ButtonAction>();
    //        if (buttonAction != null)
    //        {
    //            if (GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
    //            {
    //                GetComponent<Button>().onClick.AddListener(buttonAction.ToggleOptionButton);
    //                Debug.Log("通った");
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("ButtonManagerが見つかりません");
    //    }
    //    Debug.Log("何もなし");
    //}
    private bool isbutton = false;

    private void Update()
    {
        if (!isbutton)
        {
            if (GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
            {
                GameObject bm = GameObject.Find("ButtonManager");
                if (bm != null)
                {
                    GetComponent<Button>().onClick.AddListener(bm.GetComponent<ButtonAction>().ToggleOptionButton);
                    isbutton = true;
                }
                else
                {
                    Debug.Log("ButtonManagerが見つかりません");
                }
            }
        }
    }

    //ボタンにカーソルが重なったときのみ呼び出される
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIHoverTracker.IsPointerOverButton = true;
        //Debug.Log("true");
    }

    //カーソルがボタンから離れたときのみ呼び出される
    public void OnPointerExit(PointerEventData eventData)
    {
        UIHoverTracker.IsPointerOverButton = false;
        //Debug.Log("false");
    }
}

