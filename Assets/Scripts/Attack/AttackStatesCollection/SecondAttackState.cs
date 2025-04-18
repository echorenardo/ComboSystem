public class SecondAttackState : AttackState
{
    private readonly Timer _timer;

    public SecondAttackState(Attacker attacker, AnimationPlayer animationPlayer, Timer timer) : base(attacker, animationPlayer)
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
        _timer.Completed += OnTimerCompleted;

        _timer.Restart();
        _animationPlayer.Play(PlayerAnimations.IsSecondAttackState);
    }

    public override void OnExit()
    {
        _animationPlayer.AnimationCompleted -= OnAnimationCompleted;
        _timer.Completed -= OnTimerCompleted;

        _timer.Reset();
    }

    private void OnAnimationCompleted()
    {
        _attacker.UpdateCounter(false);

        if (_attacker.AttackQueueCounter > 0)
            _attacker.SwitchState<ThirdAttackState>();
        else
            _attacker.SwitchState<UnactiveAttackState>();
    }

    private void OnTimerCompleted()
    {
        _attacker.SwitchState<UnactiveAttackState>();
    }
}