using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    //ƒXƒy[ƒX‚ğ‰Ÿ‚·‚ÆƒJƒEƒ“ƒg‚ğ‘‚â‚·ˆ—‚ğ‚µ‚Ä‚à‚¢‚¢‚©‚Ç‚¤‚©
    public bool isSpace;
    [Header("˜A‘Å‰ñ”")]
    [SerializeField] private int pushCount = 0;

    [Header("‚Â‚©‚İ—Í”{—¦")]
    [SerializeField] private float magnification = 0.01f;
    //‰ÁZ‚·‚é”{—¦’l
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("Šî‘b’l")]
    [SerializeField] private float baseValue = -100f;
    //‰ÁZ‚·‚éŠî‘b’l
    [SerializeField] private float addBaseValue = -3f;

    [Header("ÅI’l")]
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
            //‰¼

            //”{—¦‰ÁZ
            if (Input.GetKeyDown(KeyCode.M))
            {
                AddMagnification();
                Debug.Log("”{—¦‚ª‰ÁZ‚³‚ê‚½");
            }
            //Šî‘b‰ÁZ
            if (Input.GetKeyDown(KeyCode.B))
            {
                AddBase();
                Debug.Log("Šî‘b’l‚ª‰ÁZ‚³‚ê‚½");
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
