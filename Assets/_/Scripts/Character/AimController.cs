using System;
using UnityEngine;


public class AimController : MonoBehaviour
{
  [SerializeField] private Transform _hand;
  [SerializeField] private Transform _cursor;

  public Vector3 mousePos;
  public Vector3 worldPos;

  public Vector3 aimDirection;

  public float angle;

  private void Start()
  {
    Cursor.visible= false;
  }
  void Update()
  {
    Aim();
    HandleAiming();
    HandleShooting();
  }

  private void Aim()
  {
    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    worldPos.z = 1;
    _cursor.localPosition = worldPos;
  }

  private void HandleShooting()
  {
    if (Input.GetMouseButtonDown(0))
    {
    }
  }

  private void HandleAiming()
  {
    mousePos = Input.mousePosition;
    worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    aimDirection = (worldPos - transform.position).normalized;
    angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    if (aimDirection.x < 0)
    {
      angle += 180;
      _hand.localScale = new Vector3(-1, 1, 1);
    }
    else _hand.localScale = Vector3.one;
    _hand.eulerAngles = new Vector3(0, 0, angle);
  }
}
