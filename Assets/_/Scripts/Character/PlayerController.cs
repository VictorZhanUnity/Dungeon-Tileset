using System;
using UnityEngine;
using VictorUtilities;

public class PlayerController : MonoBehaviour
{
  #region [>>> Variables]
  [SerializeField] private CharacterStatusSO _status;
  [SerializeField] private Weapon _weapon;
  [SerializeField] private Comps _comps;

  private Vector3 _aimDirection;
  private Vector3 _angleVector;
  #endregion

  #region [>>> Unity Functions]
  private void Start()
  {
    _status.weaponSO = _weapon.weaponSO;
  }

  private void Update()
  {
    Attack();
  }

  private void FixedUpdate()
  {
    Move();
    Aiming();
  }

  [ContextMenu("- GetComps")]
  private void GetComps() => _comps.GetComps(transform);
  #endregion


  /// <summary>
  /// 角色移動，按LShift可衝刺(MoveSpeed * 1.5)
  /// </summary>
  private void Move()
  {
    Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    float moveSpeed = Mathf.Clamp(direction.magnitude, 0, 1) * _status.current_MoveSpeed;

    if (Input.GetKey(KeyCode.LeftShift) && _status.isAbleToRush) moveSpeed *= 1.5f;

    direction.Normalize();
    _comps.SetMoveSpeed(moveSpeed * direction);
  }

  /// <summary>
  /// 鼠標瞄準與角色轉向
  /// </summary>
  private void Aiming()
  {
    Vector3 worldPos = VictorUtility.GetMouseWorldPos(_comps.cam);
    VictorUtility.GetDirectionToTarget(worldPos, transform.position
      , out _aimDirection, out _angleVector, true, _comps.body);
    _comps.RotateHand(_angleVector);
  }

  /// <summary>
  /// 朝向鼠標角度進行武器攻擊(近戰或射擊)
  /// </summary>
  private void Attack()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _weapon.Attack(_aimDirection, _angleVector, _status);
    }
  }


  #region [>>> Comps]
  [Serializable]
  public class Comps
  {
    [SerializeField] private Rigidbody2D _rb;
    public Camera cam;
    public Transform body;
    [SerializeField] private Transform _hand;
    [SerializeField] private Collider2D _collider2D;

    public void SetMoveSpeed(Vector2 velocity) => _rb.MovePosition(_rb.position + (velocity * Time.fixedDeltaTime));

    public void RotateHand(Vector3 handAngle)
    {
      _hand.eulerAngles = handAngle;
    }
    public void GetComps(Transform transform)
    {
      cam = Camera.main;
      _rb = transform.GetComponent<Rigidbody2D>();
      body = transform.Find("Body");
      _hand = body.Find("Hand");
      _collider2D = body.GetComponent<Collider2D>();
    }
  }
  #endregion
}
