using UnityEngine;

public class ItmGet : MonoBehaviour
{
    [SerializeField] private GameObject crane;
    [SerializeField] private TargetItem TargetItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //スターを入れた時の処理
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 10;//スコアを10点加算
        }
        //基礎パワーアップアイテムを入れたときの処理
        if (collision.gameObject.tag == "BasePowerUp")
        {
            crane.GetComponent<MagneticForceVariable>().AddBase();//クレーンの基礎パワーを増加
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            Debug.Log("基礎値パワーアップ！");
        }
        //倍率パワーアップを入れたときの処理
        if (collision.gameObject.tag == "RatePowerUp")
        {
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//クレーンの倍率パワーを増加
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            Debug.Log("倍率パワーアップ！");
        }
        //横幅パワーアップを入れたときの処理
        if (collision.gameObject.tag == "WidthPowerUp")
        {
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            Debug.Log("横幅パワーアップ！");
        }
        //ターン回復数アップを入れたときの処理
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            Debug.Log("ターン回復数アップ！");
        }
        //目標アイテムを取得した際の処理
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);//オブジェクトを削除
            
                Debug.Log("削除！");
            ScoreKeep.score += 1000;//スコアを1000点加算

            if (TargetItem.PushItem[0].name == collision.gameObject.name)
            {
                Debug.Log("目標のアイテムをゲット！");
            }
            else
            {
                Debug.Log("ターゲットアイテムをゲット！");
            }
        }
    }
}
