using UnityEngine;

/// <summary>
/// 近戰武器
/// </summary>
public class Weapon : MonoBehaviour
{
  [SerializeField] protected WeaponSO weaponSO_Data;
  public WeaponSO weaponSO => weaponSO_Data;

  public virtual void Attack(Vector3 direction, Vector3 angle, CharacterStatusSO attacker)
  {
    Debug.Log("Swing");
  }

  protected void OnValidate()
  {
    if (weaponSO_Data != null)
    {
      if (gameObject.name.Contains(weaponSO.name) == false)
        gameObject.name = weaponSO.name;
    }
  }
}
