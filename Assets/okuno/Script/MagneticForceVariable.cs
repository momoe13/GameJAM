using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    [Header("連打処理の許可")]
    // スペースを押すとカウントを増やす処理をしてもいいかどうか
    public bool isSpace;
    [Header("連打回数")]
    [SerializeField] private int pushCount = 0;

    [Header("つかみ力倍率")]
    // 現在の倍率
    [SerializeField] private float magnification = 0.01f;
    // 加算する倍率値
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("基礎値")]
    // 現在の基礎値
    [SerializeField] private float baseValue = -100f;
    // 加算する基礎値
    [SerializeField] private float addBaseValue = -3f;

    [Header("最終値")]
    // 反映させるときの最終値
    [SerializeField] private float resultValue;

    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // スペースを押したらカウントを加算
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
        resultValue = baseValue + ((magnification * pushCount) * baseValue);
        // 計算された磁力をクレーンに反映させる
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    /// <summary>
    /// つかみ力倍率を加算する（パワーアップアイテム獲得時に呼び出される）
    /// </summary>
    public void AddMagnification()
    {
        magnification += addMagnificationValue;
        //　反映させる
        Reflection();
    }

    public void AddBase()
    {
        baseValue += addBaseValue;
        // 反映させる
        Reflection();
    }
}
