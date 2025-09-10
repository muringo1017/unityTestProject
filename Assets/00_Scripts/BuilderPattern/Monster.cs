using UnityEngine;


public enum MonsterState
{
    Default, 
    Boss
}

[System.Serializable]
public class Status
{
    public int HP;
    public int ATK;
    public MonsterState state;
}
public class Monster : MonoBehaviour
{
    public Status state;
}
