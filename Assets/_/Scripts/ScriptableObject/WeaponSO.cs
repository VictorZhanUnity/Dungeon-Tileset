using UnityEngine;

[CreateAssetMenu(fileName = "New MeleeWeaponSO", menuName = "+ New/SO/Melee Weapon")]
public class WeaponSO : ScriptableObject
{
  [Range(0.1f, 10f)] public float attackPower;
  [Range(0.1f, 10f)] public float attackInterval;
  [Range(0.1f, 10f)] public float range;
}

