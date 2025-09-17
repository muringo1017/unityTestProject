using UnityEngine;


public interface IBuilder
{
    void AnimatorPart(MonsterState state);
    void StatusPart(int hp, int atk, MonsterState state);
    
    GameObject Result();
}
public class Builder : IBuilder
{

    private GameObject monsterInstance;
    private MonsterState monsterState;
    private int monsterHp;
    private int monsterAtk;

    public void AnimatorPart(MonsterState state)
    {
        
        this.monsterState = state;
    }

    public void StatusPart(int hp, int atk, MonsterState state)
    {
        // 스탯을 저장만 합니다.
        this.monsterHp = hp;
        this.monsterAtk = atk;
        // 상태를 다시 저장합니다 (선택 사항)
        this.monsterState = state;
    }

    public GameObject Result()
    {
        GameObject prefab = Resources.Load<GameObject>("Test_Character");
        if (prefab == null)
        {
            Debug.LogError("Test_Character 프리팹을 찾을 수 없습니다.");
            return null;
        }

        // 프리팹의 인스턴스를 생성합니다.
        monsterInstance = Object.Instantiate(prefab);

        // Animator 컴포넌트를 추가하고 설정합니다.
        Animator animator = monsterInstance.AddComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(monsterState.ToString());

        // Monster 컴포넌트를 추가하고 설정합니다.
        Monster monsterComponent = monsterInstance.AddComponent<Monster>();
        Status monsterStatus = new Status();
        monsterStatus.HP = monsterHp;
        monsterStatus.ATK = monsterAtk;
        monsterStatus.state = monsterState;
        monsterComponent.state = monsterStatus;

        return monsterInstance;
    }
}
