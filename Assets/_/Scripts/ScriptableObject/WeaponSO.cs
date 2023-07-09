using UnityEngine;

[CreateAssetMenu(fileName = "New MeleeWeaponSO", menuName = "+ New/SO/Melee Weapon")]
public class WeaponSO : ScriptableObject
{
  [Header(">>> 攻擊力")]
  [Range(0.1f, 10f)] public float attackPower;
  [Header(">>> 攻擊間隔")]
  [Range(0.1f, 10f)] public float attackInterval;
  [Header(">>> 攻擊範圍")]
  [Range(0.1f, 10f)] public float attackRange;
}

