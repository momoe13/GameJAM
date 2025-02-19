using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targetSelect;//クリア目標のアイテムのリスト

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//Cを押して目標を指定（仮）
        {
            //リストの中からランダムに一つが選ばれる
            int TargetNumber = Random.Range(0, targetSelect.Count);
            Debug.Log("目標のアイテムは" + targetSelect[TargetNumber]);
        }
    }
}
