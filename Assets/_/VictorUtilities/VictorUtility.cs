using UnityEngine;

namespace VictorUtilities
{
  public class VictorUtility
  {
    /// <summary>
    /// 擷取起源目標與對像目標之方向direction與角度angle，
    /// 可設定是否需要Flip來反轉角色的方向
    /// </summary>
    public static void GetDirectionToTarget(Vector3 targetPos, Vector3 sourcePos
      , out Vector3 direction, out Vector3 angleVector, bool isNeedFlip = false, Transform flipBody = null)
    {
      direction = (targetPos - sourcePos).normalized;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      Vector3 originalScale = flipBody.localScale;
      if (isNeedFlip && direction.x < 0)
      {
        angle += 180;
        if (flipBody != null) originalScale.x = Mathf.Abs(originalScale.x) * -1;
      }
      else originalScale.x = Mathf.Abs(originalScale.x);
      flipBody.localScale = originalScale;
      angleVector = new Vector3(0, 0, angle);
    }

    /// <summary>
    /// 鼠標座標轉換世界座標
    /// </summary>
    public static Vector3 GetMouseWorldPos(Camera cam = null)
    {
      cam ??= Camera.main;
      return cam.ScreenToWorldPoint(Input.mousePosition);
    }
  }
}
