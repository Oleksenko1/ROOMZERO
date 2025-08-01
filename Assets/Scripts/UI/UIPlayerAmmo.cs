using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using VContainer;

public class UIPlayerAmmo : MonoBehaviour
{
    [Inject] private PlayerWeaponController playerWeaponController;
    [SerializeField] private TextMeshProUGUI textPro;

    private int currentAmmo;
    private int maxAmmo;
    void Start()
    {
        Gun weapon = playerWeaponController.GetWeapon();

        maxAmmo = weapon.magazineCapacity;
        currentAmmo = weapon.magazineBullets;

        weapon.OnFire += ReduceAmmo;
        weapon.OnReload += ReloadAmmo;
    }
    void ReduceAmmo()
    {
        currentAmmo--;

        DOTween.Kill(textPro.rectTransform);
        textPro.rectTransform.DOPunchScale(Vector3.right * 0.5f, 0.2f);

        SetText();
    }
    void ReloadAmmo()
    {
        currentAmmo = maxAmmo;

        DOTween.Kill(textPro.rectTransform);
        textPro.rectTransform.DOPunchScale(Vector3.one * 0.5f, 0.3f);

        SetText();
    }
    void SetText()
    {
        textPro.SetText($"{currentAmmo}/{maxAmmo}");
    }
}
