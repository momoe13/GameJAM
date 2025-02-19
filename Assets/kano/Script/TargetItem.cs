using UnityEngine;

public class TargetItem : MonoBehaviour
{
    [SerializeField] GameObject[] PrfbItems; //プライズアイテムの配列

    [SerializeField] int[] ItemNumbers;　　//プライズアイテムの番号

    [SerializeField] GameObject[] PowerItems;    //強化用アイテム

    [SerializeField] public GameObject[] PushItem;//シーンに登場させるアイテム

    [SerializeField]public int targetNum;　　　　//目標となるアイテム番号

    [SerializeField]int itemNum;        　//使いまわし用変数

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//Cを押して目標を指定（仮）
        {
            //目標アイテム設定
            targetNum = Random.Range(0, ItemNumbers.Length);

            //シーンに登場させる目標アイテム
            PushItem[0] = PrfbItems[targetNum];

            //パワーアップアイテム
            itemNum = Random.Range(0, PowerItems.Length);
            PushItem[1] = PowerItems[itemNum];

            //その他プライズ
            for (int i = 0; i < PushItem.Length-2; i++) 
            {
                itemNum = Random.Range(0, ItemNumbers.Length);
                PushItem[i+2] = PrfbItems[itemNum];
            }
        }
     //   Debug.Log("目標は" + PushItem[0].ToString());

    }
}
