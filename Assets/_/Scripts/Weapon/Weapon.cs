using UnityEngine;

/// <summary>
/// 近戰武器
/// </summary>
public class Weapon : MonoBehaviour
{
  [SerializeField] private WeaponSO _waponSO;

  public virtual void Attack()
  {
    Debug.Log("Swing");
  }
}
