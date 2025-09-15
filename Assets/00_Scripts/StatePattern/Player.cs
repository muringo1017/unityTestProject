using System;
using UnityEngine;

public enum PlayerState
{
    IDLE,
    WALk
}
public class Player : MonoBehaviour
{
    private IState currentState;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetState(new IDLE_State());
    }

    private void SetState(IState state)
    {
        currentState = state;
        currentState.Input(this, state.ToString());
    }

    public void AnimatiorChange(string name)
    {
        animator.SetBool("isIDLE", false);
        animator.SetBool("isRUN", false);
        
        animator.SetBool(name, true);
    }
    private void InputHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal != 0)
            SetState(new RUN_State());
        
        else
            SetState(new IDLE_State());
    }

    private void Update()
    {
        InputHandler();
        currentState.Update(this);
    }
}
