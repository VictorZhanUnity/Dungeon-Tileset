using UnityEngine;

namespace VictorUtilties.Managers
{
  /// <summary>
  /// 用於攻擊間隔判斷機制
  /// </summary>
  public class FireRateSystem : MonoBehaviour
  {
    #region [>>> Private]
    [SerializeField] private float _fireRate = 0.5f;
    private float _coldDownTime = 0;
    private void Update()
    {
      if (isCoolDownFinished) return;
      _coldDownTime = Mathf.Max(0, _coldDownTime - Time.deltaTime);
    }
    #endregion
    public bool isCoolDownFinished => _coldDownTime <= 0;
    public void Activated() => _coldDownTime = _fireRate;
    public void SetAttackRate(float value) => _fireRate = value;
  }
}
