using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [Header("Player")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAim playerAim;
    [SerializeField] private PlayerWeaponController playerWeaponController;
    [Header("UI")]
    [SerializeField] private UIPlayerAmmo uIPlayerAmmo;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(playerController).AsSelf();
        builder.RegisterComponent(playerMovement).AsSelf();
        builder.RegisterComponent(playerAim).AsSelf();
        builder.RegisterComponent(playerWeaponController).AsSelf();
        builder.RegisterComponent(uIPlayerAmmo).AsSelf();
    }
}
