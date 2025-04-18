public class ThirdAttackState : AttackState
{
    public ThirdAttackState(Attacker attacker, AnimationPlayer animationPlayer) : base(attacker, animationPlayer) {}

    public override void OnActivated()
    {
        _attacker.UpdateCounter(true);
    }

    public override void OnEnter()
    {
        _animationPlayer.AnimationCompleted += OnAnimationCompleted;

        _animationPlayer.Play(PlayerAnimations.IsThirdAttackState);
    }

    public override void OnExit()
    {
        _animationPlayer.AnimationCompleted -= OnAnimationCompleted;
    }

    private void OnAnimationCompleted()
    {
        _attacker.UpdateCounter(false);

        _attacker.SwitchState<UnactiveAttackState>();
    }
}