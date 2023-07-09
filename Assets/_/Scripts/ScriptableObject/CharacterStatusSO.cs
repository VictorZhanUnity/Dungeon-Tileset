using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSO", menuName = "+ New/SO/Character")]
public class CharacterStatusSO : ScriptableObject
{
  [Range(0.1f, 10f)]public float moveSpeed;
  [Range(0.1f, 10f)]public float attackPower;
  [Range(0.1f, 10f)]public float attackInterval;
  [Range(0.1f, 10f)]public float attackRange = 1;

  public WeaponSO weaponSO;
  public float current_MoveSpeed => moveSpeed;
  public float current_AttackPower=> attackPower + weaponSO.attackPower;
  public float current_AttackInterval => attackInterval + weaponSO.attackInterval;
  public float current_AttackRange=> attackRange + weaponSO.attackRange;

  /// <summary>
  /// 偵測體力值是否能夠進行衝刺
  /// </summary>
  public bool isAbleToRush => true;

}
