using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image healthPoint;
    public Image healthEffect;

    private BossHealth Boss;

    // Start is called before the first frame update
    private void Awake()
    {
        Boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthPoint.fillAmount = Boss.health / Boss.MaxHealth;
        if (healthEffect.fillAmount> healthPoint.fillAmount)
        {
            healthEffect.fillAmount -= 0.003f;

        }
        else
        {
            healthEffect.fillAmount = healthPoint.fillAmount;
        }
    }
}
