using UnityEngine;

public class InputController : MonoBehaviour
{
    private readonly KeyCode _attackKey = KeyCode.J;

    [SerializeField] private Attacker _attacker;

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey))
            _attacker.Attack();
    }
}