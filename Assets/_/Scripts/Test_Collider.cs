using UnityEngine;

public class Test_Collider : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log($">>> Tester - OnCollisionEnter2D: {collision.gameObject.name}");
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log($">>> Tester - OnTriggerEnter2D: {collision.transform.parent.name}");
    if (collision.transform.parent.TryGetComponent(out Projectile projectile))
    {
      CharacterStatusSO attacker = projectile.owner;
      Debug.Log($"name: {attacker.name} / Power: {attacker.current_AttackPower}");
    }
  }
}
