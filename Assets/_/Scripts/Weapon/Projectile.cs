using UnityEngine;

public class Projectile : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rb;
  public CharacterStatusSO owner { get; private set; }
  public void SetOwner(CharacterStatusSO owner) => this.owner = owner;

  public void Shoot(Vector3 direction, Vector3 angle, float projectileSpeed)
  {
    transform.eulerAngles = angle;
    if (direction.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    _rb.velocity = projectileSpeed * direction;
    Destroy(gameObject, 5);
  }
}
