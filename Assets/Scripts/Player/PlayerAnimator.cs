using UnityEngine;
using System.Collections;

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

    [SerializeField]
    private float _longIdleDelay = 3;
    private Coroutine _longIdleCoroutine;


    private void Update()
    {
        if (_animator == null) return;
        _animator.SetFloat("Forward", ForwardAmount * _forwardMultiplier, 0.15f, Time.deltaTime);
        _animator.SetFloat("Turn", TurnAmount * _turnMultiplier, 0.25f, Time.deltaTime);
        CheckLongIdle();
    }


    private void CheckLongIdle()
    {
        if (ForwardAmount + TurnAmount != 0)
        {
            if (_longIdleCoroutine == null) return;
            StopCoroutine(_longIdleCoroutine);
            _longIdleCoroutine = null;
            NormalAnimation();
        }
        else
        {
            if (_longIdleCoroutine != null) return;
            _longIdleCoroutine = StartCoroutine(LongIdle());
        }
    }


    private void NormalAnimation()
    {
        _animator.applyRootMotion = false;
        _animator.SetBool("LongIdle", false);
    }


    private void LongIdleAnimation()
    {
        _animator.applyRootMotion = true;
        _animator.SetBool("LongIdle", true);
    }


    private IEnumerator LongIdle()
    {
        yield return new WaitForSeconds(_longIdleDelay);
        LongIdleAnimation();
    }
}
