using UnityEngine.UI;
using UnityEngine;

public class UiBlink : MonoBehaviour
{
    [SerializeField] private float T;
    //[SerializeField] private float furehaba;
    private Color newColor;
    private Image image;
    private float f;
    private float sin;

    void Start()
    {
        f = 1.0f / T;
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        sin = Mathf.Sin(2 * Mathf.PI * f * Time.time + Mathf.PI / 2);
        // byte‚É•ÏŠ·‚µA”ÍˆÍ‚ğ0`255‚É‚·‚é
        byte alpha = (byte)((1 + sin) / 2 * 255);
        newColor = image.color;
        // 0.0`1.0‚É³‹K‰»
        newColor.a = alpha / 255f;
        image.color = newColor;
    }
}
