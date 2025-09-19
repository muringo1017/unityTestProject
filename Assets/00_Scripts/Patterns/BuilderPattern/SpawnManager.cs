using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IBuilder builder = new Builder();
        builder.AnimatorPart(MonsterState.Default);
        builder.StatusPart(10, 3, MonsterState.Default);
        GameObject monster = builder.Result();
    }

   
}
