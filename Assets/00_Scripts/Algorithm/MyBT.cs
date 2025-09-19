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
        _animator = GetComponent<Animator>();
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
        // 공격 중에는 이동하지 않도록 정지시킵니다.
        // (이 코드가 없어도 Running 상태 때문에 ChasePlayer가 실행되지 않지만, 명시적으로 추가)
        
        // GetComponent<Rigidbody>().velocity = Vector3.zero;

        // 현재 애니메이터의 상태 정보를 가져옵니다.
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        // 이미 ATTACK 애니메이션이 실행 중인지 확인합니다.
        if (stateInfo.IsName("ATTACK"))
        {
            // 애니메이션이 재생 중이면(끝나지 않았으면) Running을 반환하여 상태를 유지합니다.
            if (stateInfo.normalizedTime < 1.0f)
            {
                return MyNodeStatus.Running;
            }
            // 애니메이션이 끝났다면 Success를 반환하여 트리가 다시 평가되도록 합니다.
            else
            {
                return MyNodeStatus.Success;
            }
        }
        // ATTACK 애니메이션이 실행 중이 아니라면, 이제 시작시킵니다.
        else
        {
            Rotate(); // 공격 시작 직전에만 방향을 돌도록 위치 변경
            AnimatorChange("ATTACK");
            // 애니메이션을 방금 시작했으므로 Running을 반환하여 다음 프레임부터 상태를 체크하도록 합니다.
            return MyNodeStatus.Running;
        }
    }
    MyNodeStatus IDLE()
    {
        AnimatorChange("IDLE");
        return MyNodeStatus.Success;
    }

    MyNodeStatus ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
  

        Rotate();
        AnimatorChange("MOVE");
        
        return MyNodeStatus.Running;
        
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
