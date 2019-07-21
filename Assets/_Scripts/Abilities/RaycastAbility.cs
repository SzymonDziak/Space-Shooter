using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities/RaycastAbility")]
public class RaycastAbility : Ability
{
    private WeaponController weaponController;

    public override void Initialize(GameObject obj)
    {
        weaponController = obj.GetComponent<WeaponController>();
    }
    public override void TriggerAbility()
    {
        weaponController.Fire();
    }
}
