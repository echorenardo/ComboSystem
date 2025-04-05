public abstract class AttackState
{
    protected Attacker _attacker;
    protected AnimationPlayer _animationPlayer;

    public AttackState(Attacker attacker, AnimationPlayer animationPlayer)
    {
        _attacker = attacker;
        _animationPlayer = animationPlayer;
    }

    public abstract void OnActivated();
    public abstract void OnEnter();
    public abstract void OnExit();
}
