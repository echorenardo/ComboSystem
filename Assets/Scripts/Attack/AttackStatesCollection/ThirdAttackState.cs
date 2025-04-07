public class ThirdAttackState : AttackState
{
    private readonly Timer _timer;

    public ThirdAttackState(Attacker attacker, AnimationPlayer animationPlayer, Timer timer) : base(attacker, animationPlayer)
    {
        _timer = timer;
    }

    public override void OnActivated()
    {
        _attacker.UpdateCounter(true);
    }

    public override void OnEnter()
    {
        _animationPlayer.AnimationCompleted += OnAnimationCompleted;

        _timer.Restart();
        _animationPlayer.Play(PlayerAnimations.IsThirdAttackState);
    }

    public override void OnExit()
    {
        _timer.Reset();
    }

    private void OnAnimationCompleted()
    {
        _animationPlayer.AnimationCompleted -= OnAnimationCompleted;

        _attacker.UpdateCounter(false);

        _attacker.SwitchState<UnactiveAttackState>();
    }
}