using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour
{
    [SerializeField] List<GameObject> PrfbItem;//全アイテムの配列

    [SerializeField]int[] ItemNumbers;　　//全アイテムの番号

    [SerializeField]GameObject[] PushItem;//シーンに登場させるアイテム

    [SerializeField]int targetNum;　　　　//目標となるアイテム番号

    [SerializeField]int itemNum;        　//

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//Cを押して目標を指定（仮）
        {
            //目標アイテム設定
            targetNum =  Random.Range(0, ItemNumbers.Length);

            //シーンに登場させるアイテム
            PushItem[0] = PrfbItem[targetNum];

           //PrfbItem.Remove(targetNum);
        }

    }
}
