public class SecondAttackState : AttackState
{
    public SecondAttackState(Attacker attacker, AnimationPlayer animationPlayer) : base(attacker, animationPlayer) {}

    public override void OnActivated()
    {
        _attacker.UpdateCounter(true);
    }

    public override void OnEnter()
    {
        _animationPlayer.AnimationCompleted += OnAnimationCompleted;

        _animationPlayer.Play(PlayerAnimations.IsSecondAttackState);
    }

    public override void OnExit()
    {
        _animationPlayer.AnimationCompleted -= OnAnimationCompleted;
    }

    private void OnAnimationCompleted()
    {
        _attacker.UpdateCounter(false);

        if (_attacker.AttackQueueCounter > 0)
            _attacker.SwitchState<ThirdAttackState>();
        else
            _attacker.SwitchState<UnactiveAttackState>();
    }
}