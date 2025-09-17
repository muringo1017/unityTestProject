using System;
using UnityEngine;
using System.Collections.Generic;
public class MyBT : MonoBehaviour
{
    private MyNode _root;
    private Animator _animator;

    public Transform target;
    public float speed = 2.0f;
    public float chaseRange =  5.0f;
    public float attackRange = 1.5f;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _root = new MySelector(new List<MyNode>
            {
                new MySequence(new List<MyNode>
                {
                    new MyLeaf(CheckPlayerInRange), 
                    new MyLeaf(AttackPlayer)
                    
                }),
                new MySequence(new List<MyNode>
                {
                    new MyLeaf(CheckChaseRange),
                    new MyLeaf(ChasePlayer)
                }),
                new MyLeaf(IDLE)
            });
    }

    private void Update()
    {
        _root.Evaluate();
    }


    private MyNodeStatus RangeCheck(float range)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < range ? MyNodeStatus.Success : MyNodeStatus.Failure;
    }
    MyNodeStatus CheckChaseRange()
    {
        return RangeCheck(chaseRange);
    }
    MyNodeStatus CheckPlayerInRange()
    {
        return RangeCheck(attackRange);
    }

    MyNodeStatus AttackPlayer()
    {
        Rotate();
        AnimatorChange("ATTACK");
        return MyNodeStatus.Success;
    }
    MyNodeStatus IDLE()
    {
        AnimatorChange("IDLE");
        return MyNodeStatus.Success;
    }

    MyNodeStatus ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        return MyNodeStatus.Success;
    }

    void Rotate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0.0f;
        transform.forward = direction;
    }
    private void AnimatorChange(string temp)
    {
        _animator.SetBool("IDLE", false);
        _animator.SetBool("MOVE", false);
        _animator.SetBool("ATTACK", false);
        
        _animator.SetBool(temp, true);
    }
}
