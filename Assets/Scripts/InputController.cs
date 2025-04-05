using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;

    private readonly KeyCode _attackKey = KeyCode.J;

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey))
            _attacker.Attack();
    }
}
