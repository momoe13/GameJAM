using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    //スペースを押すとカウントを増やす処理をしてもいいかどうか
    public bool isSpace;
    [Header("連打回数")]
    [SerializeField] private int pushCount = 0;

    [Header("つかみ力倍率")]
    [SerializeField] private float magnification = 0.01f;
    //加算する倍率値
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("基礎値")]
    [SerializeField] private float baseValue = -100f;
    //加算する基礎値
    [SerializeField] private float addBaseValue = -3f;

    [Header("最終値")]
    [SerializeField] private float resultValue;
    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pushCount++;
                Reflection();
            }
            //仮

            //倍率加算
            if (Input.GetKeyDown(KeyCode.M))
            {
                AddMagnification();
                Debug.Log("倍率が加算された");
            }
            //基礎加算
            if (Input.GetKeyDown(KeyCode.B))
            {
                AddBase();
                Debug.Log("基礎値が加算された");
            }
        }        
    }

    public void Reflection()
    {
        resultValue = baseValue + ((magnification * pushCount) * baseValue);
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    public void AddMagnification()
    {
        magnification = magnification + addMagnificationValue;
        Reflection();
    }

    public void AddBase()
    {
        baseValue = baseValue + addBaseValue;
        Reflection();
    }
}
