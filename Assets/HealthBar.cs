using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthPoint;
    public Image healthEffect;

    private PlayerHealth player;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthPoint.fillAmount = player.health / player.maxHealth;
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
