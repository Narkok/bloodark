using UnityEngine;

public class PlayerAnimator: MonoBehaviour
{

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _turnMultiplier = 0.3f;
    public float TurnAmount;

    [SerializeField]
    private float _forwardMultiplier = 0.4f;
    public float ForwardAmount;


    void Update()
    {
        if (_animator == null) return;
        _animator.SetFloat("Forward", ForwardAmount * _forwardMultiplier, 0.15f, Time.deltaTime);
        _animator.SetFloat("Turn", TurnAmount * _turnMultiplier, 0.25f, Time.deltaTime);
    }
}
