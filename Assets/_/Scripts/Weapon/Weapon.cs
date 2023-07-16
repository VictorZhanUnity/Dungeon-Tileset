using UnityEngine;
using VictorUtilties.Managers;

/// <summary>
/// 近戰武器
/// </summary>
public class Weapon : MonoBehaviour
{
  [SerializeField] protected WeaponSO weaponSO_Data;
  [SerializeField] protected FireRateSystem fireRateSystem;
  /// <summary>
  /// 供外部的PlayerController擷取，給CharacterStatusSO統計數值用
  /// </summary>
  public WeaponSO weaponSO => weaponSO_Data;

  public virtual void Attack(Vector3 direction, Vector3 angle, CharacterStatusSO attacker)
  {
    Debug.Log("Swing");
  }

  protected bool isAbleToAttack => fireRateSystem.isCoolDownFinished;

  protected void AttackActivated() => fireRateSystem.Activated();

  protected void OnValidate()
  {
    if (weaponSO_Data != null)
    {
      if (gameObject.name.Contains(weaponSO_Data.name) == false)
        gameObject.name = weaponSO_Data.name;
      fireRateSystem.SetAttackRate(weaponSO_Data.attackInterval);
    }
  }

  [ContextMenu("- GetComps")]
  private void GetComps()
  {
    fireRateSystem = GetComponent<FireRateSystem>();
  }
}
