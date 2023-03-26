using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image playerHPimage;

    [SerializeField]
    private PlayerController playerController;

    private float maxHPBar;

    void Start()
    {
        playerHPimage = GetComponent<Image>();

        maxHPBar = playerController.healthPlayer;

    }

    void Update()
    {
        playerHPimage.fillAmount = playerController.healthPlayer / maxHPBar;
    }
}
