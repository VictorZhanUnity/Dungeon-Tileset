using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  #region [>>> Variables]
  [SerializeField] private CharacterStatusSO _status;
  [SerializeField] private Comps _comps;
  [SerializeField] private Weapon _weapon;

  private float _moveSpeed;
  #endregion

  #region [>>> Unity Functions]
  private void FixedUpdate()
  {
    Move();
    Aiming();
    Attack();
  }

  private void Attack()
  {
    if (Input.GetMouseButtonDown(0)) _weapon.Attack();
  }

  [ContextMenu("- GetComps")]
  private void GetComps() => _comps.GetComps(transform);
  #endregion

  private void Move()
  {
    Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    _moveSpeed = Mathf.Clamp(direction.magnitude, 0, 1) * _status.current_MoveSpeed;

    if (Input.GetKey(KeyCode.LeftShift) && isAbleToRush) _moveSpeed *= 1.5f;

    direction.Normalize();
    _comps.SetMoveSpeed(_moveSpeed * direction);
  }

  private void Aiming()
  {
    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 aimDirection = (worldPos - transform.position).normalized;
    float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    _comps.Aim(angle, aimDirection.x < 0);
  }

  /// <summary>
  /// 偵測體力值是否能夠進行衝刺
  /// </summary>
  private bool isAbleToRush => true;

  #region [>>> Comps]
  [Serializable]
  public class Comps
  {
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _hand;
    [SerializeField] private Collider2D _collider2D;
    public void SetMoveSpeed(Vector2 velocity) => _rb.MovePosition(_rb.position + (velocity * Time.fixedDeltaTime));
    public void Aim(float angle, bool isFlip)
    {
      _body.localScale = new Vector3(isFlip ? -1 : 1, 1, 1);
      if (isFlip) angle += 180;
      _hand.eulerAngles = new Vector3(0, 0, angle);
    }
    public void GetComps(Transform transform)
    {
      _rb = transform.GetComponent<Rigidbody2D>();
      _body = transform.Find("Body");
      _hand = _body.Find("Hand");
      _collider2D = _body.GetComponent<Collider2D>();
    }
  }
  #endregion
}
