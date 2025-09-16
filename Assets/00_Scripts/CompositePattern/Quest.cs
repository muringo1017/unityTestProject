using UnityEngine;

public class Quest : MonoBehaviour
{

    void Start()
    {
        IComposite monsterHunter = new MonsterHunter("오우거를 잡아라", "50마르릴 잡아라");
        IComposite getItem = new GetItem("종잇 ㅜ집", "15장");
        IComposite BossMonsterHunter = new MonsterHunter("거대용", "거대용 으흐흐흐");
        
        CompositePattern compositePattern = new CompositePattern();
        compositePattern.Add(monsterHunter);
        compositePattern.Add(getItem);
        compositePattern.Add(BossMonsterHunter);
        
        compositePattern.Show();
    }

 
}
