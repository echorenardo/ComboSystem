public abstract class AttackState: State<Attacker>
{
    protected Attacker _attacker;
    protected AnimationPlayer _animationPlayer;

    public AttackState(Attacker attacker, AnimationPlayer animationPlayer): base(attacker)
    {
        _attacker = attacker;
        _animationPlayer = animationPlayer;
    }
}