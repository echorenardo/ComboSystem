using UnityEngine;

public class Attacker : MonoBehaviour
{
    private readonly float _timeForReset = 1f;

    [SerializeField] private AnimationPlayer _animationPlayer;
    [SerializeField] private Timer _timer;

    private StateMachine<Attacker, AttackState> _stateMachine;

    public AttackState CurrentState { get; private set; }
    public int AttackQueueCounter { get; private set; }

    private void Start()
    {
        _stateMachine = new StateMachine<Attacker, AttackState>(this);

        FillStates();
        _timer.Setup(_timeForReset);

        _stateMachine.SetInitialState<UnactiveAttackState>();
    }

    public void Attack()
    {
        _stateMachine.Activate();
    }

    public void SwitchState<TState>() where TState : AttackState
    {
        _stateMachine.SwitchState<TState>();
    }

    public void UpdateCounter(bool isIncrement)
    {
        int valueToUpdate = isIncrement ? 1 : -1;
        AttackQueueCounter = Mathf.Clamp(AttackQueueCounter + valueToUpdate, 0, _stateMachine.StatesCount - 1);
    }

    public void ResetAttackCounter()
    {
        AttackQueueCounter = 0;
    }

    private void FillStates()
    {
        _stateMachine.AddState(new UnactiveAttackState(this, _animationPlayer));
        _stateMachine.AddState(new FirstAttackState(this, _animationPlayer, _timer));
        _stateMachine.AddState(new SecondAttackState(this, _animationPlayer, _timer));
        _stateMachine.AddState(new ThirdAttackState(this, _animationPlayer, _timer));
    }
}