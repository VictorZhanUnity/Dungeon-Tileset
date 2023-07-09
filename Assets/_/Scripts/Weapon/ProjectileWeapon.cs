using UnityEngine;

/// <summary>
/// 弓或法杖
/// </summary>
public class ProjectileWeapon : Weapon
{
  [SerializeField] private Transform _firePoint;

  public override void Attack(Vector3 direction, Vector3 angle, CharacterStatusSO attacker)
  {
    ProjectileWeaponSO projectileWeaponSO = weaponSO_Data as ProjectileWeaponSO;
    GameObject bullet = Instantiate(projectileWeaponSO.bullet, _firePoint.position, Quaternion.identity);
    if (bullet.TryGetComponent(out Projectile projectile))
    {
      projectile.SetOwner(attacker);
      projectile.Shoot(direction, angle, projectileWeaponSO.projectileSpeed);
    }
  }

}
