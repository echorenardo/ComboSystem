public class FirstAttackState : AttackState
{
    public FirstAttackState(Attacker attacker, AnimationPlayer animationPlayer): base(attacker, animationPlayer) {}

    public override void OnActivated()
    {
        _attacker.UpdateCounter(true);
    }

    public override void OnEnter()
    {
        _animationPlayer.AnimationCompleted += OnAnimationCompleted;

        _animationPlayer.Play(PlayerAnimations.IsFirstAttackState);
    }

    public override void OnExit()
    {
        _animationPlayer.AnimationCompleted -= OnAnimationCompleted;
    }

    private void OnAnimationCompleted()
    {
        _attacker.UpdateCounter(false);

        if (_attacker.AttackQueueCounter > 0)
            _attacker.SwitchState<SecondAttackState>();
        else
            _attacker.SwitchState<UnactiveAttackState>();
    }
}