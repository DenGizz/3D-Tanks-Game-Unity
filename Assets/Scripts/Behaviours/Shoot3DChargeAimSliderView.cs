using Assets.Scripts.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Shoot3DChargeAimSliderView : MonoBehaviour
{
    [SerializeField] private Slider _aimSlider;

    private IShootable _shootable;

    [Inject]
    public void Construct(IShootable shootable)
    {
        _shootable = shootable;
    }

    private void OnEnable()
    {
        _aimSlider.value = _shootable.MinLaunchForce;
    }

    private void Update()
    {
        _aimSlider.value = _shootable.CurrentLaunchForce;
    }
}
