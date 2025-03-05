using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public enum State
    {
        ZERO,
        ONE,
        TWO,
        THREE,
        FOUR,
    }
    private State state;
    [SerializeField] private GameObject powerErea;
    [SerializeField] private int[] craneLevelUpValue;
    [SerializeField] private GameObject[] gaugeAry;
    [SerializeField] private GameObject gaugeParticleParent;
    [Header("ゲージパーティクルの座標")]
    [SerializeField] private Vector3[] particlePosition;
    [Header("-------------------------------------")]
    [SerializeField] private ParticleSystem gaugeParticleLeft;
    [SerializeField] private ParticleSystem gaugeParticleRight;
    private int idx = 0;

    private void Start()
    {
        StartCoroutine(StateChange());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    GaugeReset();
        //}
    }

    private IEnumerator StateChange()
    {
        while (true)
        {
            switch (state)
            {
                case State.ZERO:
                    if(powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.ZERO]) { break; }
                    gaugeParticleLeft.Play();
                    gaugeParticleRight.Play();
                    gaugeParticleParent.transform.localPosition = particlePosition[idx];
                    gaugeAry[idx].gameObject.SetActive(true);
                    idx++;
                    state = State.ONE;
                    break;
                case State.ONE:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.ONE]) { break; }
                    gaugeParticleParent.transform.localPosition = particlePosition[idx];
                    gaugeAry[idx].gameObject.SetActive(true);
                    idx++;
                    state = State.TWO;
                    break;
                case State.TWO:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.TWO]) { break; }
                    gaugeParticleParent.transform.localPosition = particlePosition[idx];
                    gaugeAry[idx].gameObject.SetActive(true);
                    idx++;
                    state = State.THREE;
                    break;
                case State.THREE:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.THREE]) { break; }
                    gaugeParticleParent.transform.localPosition = particlePosition[idx];
                    gaugeAry[idx].gameObject.SetActive(true);
                    state = State.FOUR;
                    break;
            }
            yield return null;
        }
    }

    public void GaugeReset()
    {
        for (idx = 3; idx >= 0; idx--)
        {
            gaugeAry[idx].SetActive(false);
        }
        idx = 0;
        gaugeParticleLeft.Stop();
        gaugeParticleRight.Stop();
        gaugeParticleParent.transform.localPosition = particlePosition[idx];
        state = State.ZERO;
    }
}
