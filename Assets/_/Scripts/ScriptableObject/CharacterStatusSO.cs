using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSO", menuName = "+ New/SO/Character")]
public class CharacterStatusSO : ScriptableObject
{
  [Range(0.1f, 10f)]public float moveSpeed;
  public float current_MoveSpeed => moveSpeed;
}
