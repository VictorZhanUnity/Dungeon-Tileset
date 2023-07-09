using UnityEngine;

[CreateAssetMenu(fileName = "New ProjectileWeaponSO", menuName = "+ New/SO/Projectile Weapon")]
public class ProjectileWeaponSO : WeaponSO
{
  public GameObject bullet;
  [Range(1f, 100f)] public float projectileSpeed;
}
