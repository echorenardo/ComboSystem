using System;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private readonly float _timeForReset = 1f;

    [SerializeField] private AnimationPlayer _animationPlayer;
    [SerializeField] private Timer _timer;

    private Dictionary<Type, AttackState> _states = new();

    public AttackState CurrentState { get; private set; }
    public int AttackQueueCounter { get; private set; }

    private void Start()
    {
        FillStates();
        _timer.Setup(_timeForReset);

        CurrentState = _states[typeof(UnactiveAttackState)];
    }

    public void Attack()
    {
        CurrentState.OnActivated();
    }

    public void SwitchState<T>() where T : AttackState
    {
        Type type = typeof(T);

        if (_states.ContainsKey(type) == false)
            throw new Exception("This state not exists");

        AttackState newState = _states[type];

        if (newState == CurrentState)
            return;

        CurrentState?.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }

    public void UpdateCounter(bool isIncrement)
    {
        int valueToUpdate = isIncrement ? 1 : -1;
        AttackQueueCounter = Mathf.Clamp(AttackQueueCounter + valueToUpdate, 0, _states.Count - 1);
    }

    public void ResetAttackCounter()
    {
        AttackQueueCounter = 0;
    }

    private void FillStates()
    {
        _states.Add(typeof(UnactiveAttackState), new UnactiveAttackState(this, _animationPlayer));
        _states.Add(typeof(FirstAttackState), new FirstAttackState(this, _animationPlayer, _timer));
        _states.Add(typeof(SecondAttackState), new SecondAttackState(this, _animationPlayer, _timer));
        _states.Add(typeof(ThirdAttackState), new ThirdAttackState(this, _animationPlayer, _timer));
    }
}