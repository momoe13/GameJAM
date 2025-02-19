using UnityEngine;

public class MagneticForceManager : MonoBehaviour
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
        // 初期化
        AllValueReset();
    }

    public void GetKey()
    {
        pushCount++;
        Reflection();
    }

    /// <summary>
    /// クレーンの磁力を完全にオフにする（オンにする場合Reflection()を呼び出す）
    /// </summary>
    public void MagneticOff()
    {
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = 0;
    }

    /// <summary>
    /// クレーンの磁力関係の値を初期化
    /// </summary>
    public void AllValueReset()
    {
        magnificationValue = initialMagnification;
        baseValue = initialBase;
        pushCount = 0;
        // クレーンに反映
        Reflection();
    }

    /// <summary>
    /// クレーンに磁力の値を反映させるメソッド(磁力を戻したい場合もこれを呼び出す）
    /// </summary>
    public void Reflection()
    {
        // 最終値の計算
        resultValue = baseValue + ((magnificationValue * pushCount) * baseValue);
        // 計算された磁力をクレーンに反映させる
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    /// <summary>
    /// 連打回数のみリセット
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
        // クレーンに反映
        Reflection();
    }


    /// <summary>
    /// 基礎値を加算する（パワーアップアイテム獲得時に呼び出される）
    /// </summary>
    public void AddBase()
    {
        baseValue += addBaseValue;
        // クレーンに反映
        Reflection();
    }
}

