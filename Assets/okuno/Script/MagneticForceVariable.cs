using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    [Header("連打処理の許可")]
    // スペースを押すとカウントを増やす処理をしてもいいかどうか
    public bool isSpace;
    [Header("連打回数")]
    [SerializeField] private int pushCount = 0;

    [Header("つかみ力倍率")]
    // 初期値
    [SerializeField] private float initialMagnification = 0.01f;
    // 現在の倍率
    [SerializeField] private float magnificationValue;
    // 加算する倍率値
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("基礎値")]
    // 初期値
    [SerializeField] private float initialBase = -100f;
    // 現在の基礎値
    [SerializeField] private float baseValue;
    // 加算する基礎値
    [SerializeField] private float addBaseValue = -3f;

    [Header("最終値")]
    // 反映させるときの最終値
    [SerializeField] private float resultValue;

    void Start()
    {
        // 最初に基礎値と倍率を初期値に設定し、反映させる
        magnificationValue = initialMagnification;
        baseValue = initialBase;
        Reflection();
    }

    void Update()
    {
        // isSpaceがtrueの間のみ、連打回数加算を許可する
        if (isSpace)
        {
            // スペースを押したらカウントを加算
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pushCount++;
                Reflection();
            }
        }        
    }

    /// <summary>
    /// クレーンに磁力の値を反映させるメソッド
    /// </summary>
    public void Reflection()
    {
        // 最終値の計算
        resultValue = baseValue + ((magnificationValue * pushCount) * baseValue);
        // 計算された磁力をクレーンに反映させる
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    /// <summary>
    /// 連打回数をリセット
    /// </summary>
    public void ResetPushCount()
    {
        pushCount = 0;
    }

    /// <summary>
    /// つかみ力倍率を加算する（パワーアップアイテム獲得時に呼び出される）
    /// </summary>
    public void AddMagnification()
    {
        magnificationValue += addMagnificationValue;
        // 反映させる
        Reflection();
    }


    /// <summary>
    /// 基礎値を加算する（パワーアップアイテム獲得時に呼び出される）
    /// </summary>
    public void AddBase()
    {
        baseValue += addBaseValue;
        // 反映させる
        Reflection();
    }
}
