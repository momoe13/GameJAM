using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetManager : MonoBehaviour
{
    [SerializeField] private GameObject ScoreMgr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            ScoreMgr.GetComponent<ScoreManager>().score += 10;
        }
        if (collision.gameObject.tag == "PowerUp")
        {
            Destroy(collision.gameObject);
            ScoreMgr.GetComponent<ScoreManager>().score += 100;
            Debug.Log("パワーアップ！");
        }
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
            ScoreMgr.GetComponent<ScoreManager>().score += 1000;
            Debug.Log("目標のアイテムをゲット！");
        }
    }
}
