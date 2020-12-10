using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    [SerializeField] private LifeController lifeController = null;
    [SerializeField] private Image lifebar;

    private void Awake()
    {
        lifeController.OnLifeChange += OnLifeChangeHandler;
    }

    void OnLifeChangeHandler(float currentLife)
    {
        UpdateLifebar();
    }

    void UpdateLifebar()
    {
        lifebar.fillAmount = lifeController.GetLifePercentage();
    }
}
