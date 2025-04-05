using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public static readonly int IsUnactiveAttackState = Animator.StringToHash(nameof(IsUnactiveAttackState));
    public static readonly int IsFirstAttackState = Animator.StringToHash(nameof(IsFirstAttackState));
    public static readonly int IsSecondAttackState = Animator.StringToHash(nameof(IsSecondAttackState));
    public static readonly int IsThirdAttackState = Animator.StringToHash(nameof(IsThirdAttackState));
}
