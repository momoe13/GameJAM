using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour
{
    [SerializeField] List<GameObject> PrfbItem;//�S�A�C�e���̔z��

    [SerializeField]int[] ItemNumbers;�@�@//�S�A�C�e���̔ԍ�

    [SerializeField]GameObject[] PushItem;//�V�[���ɓo�ꂳ����A�C�e��

    [SerializeField]int targetNum;�@�@�@�@//�ڕW�ƂȂ�A�C�e���ԍ�

    [SerializeField]int itemNum;        �@//

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//C�������ĖڕW���w��i���j
        {
            //�ڕW�A�C�e���ݒ�
            targetNum =  Random.Range(0, ItemNumbers.Length);

            //�V�[���ɓo�ꂳ����A�C�e��
            PushItem[0] = PrfbItem[targetNum];

           //PrfbItem.Remove(targetNum);
        }

    }
}
