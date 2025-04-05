public class UnactiveAttackState : AttackState
{
    public UnactiveAttackState(Attacker attacker, AnimationPlayer animationPlayer) : base(attacker, animationPlayer) { }

    public override void OnActivated()
    {
        _attacker.UpdateCounter(true);

        _attacker.SwitchState<FirstAttackState>();
    }

    public override void OnEnter()
    {
        _attacker.ResetAttackCounter();

        _animationPlayer.Play(PlayerAnimations.IsUnactiveAttackState);
    }

    public override void OnExit()
    {

    }
}
