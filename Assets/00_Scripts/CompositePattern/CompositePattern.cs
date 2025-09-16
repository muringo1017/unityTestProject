using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum QuestType
{
    MonsterHunter,
    GetItem,
    BossMonsterHunting
}

public interface IComposite
{
    void Show();
}

public class CompositePattern : IComposite
{
    public List<IComposite> _composites = new List<IComposite>();
    public void Add(IComposite composite)
    {
        _composites.Add(composite);
    }

    public void Show()
    {
        foreach (IComposite composite_ in _composites)
        {
            composite_.Show();
        }
    }

    public void Remove(IComposite composite)
    {
        _composites.Remove(composite);
    }
}

public class MonsterHunter : IComposite
{
    private string QuestTitle;
    private string QuestDescription;


    public MonsterHunter(string questTitle, string questDescription)
    {
        QuestTitle = questTitle;
        QuestDescription = questDescription;
    }
    
    public void Show()
    {
        Debug.Log("MonsterHunter" + QuestTitle + "\n" + QuestDescription);
    }
}

public class GetItem : IComposite
{
    private string QuestTitle;
    private string QuestDescription;


    public GetItem(string questTitle, string questDescription)
    {
        QuestTitle = questTitle;
        QuestDescription = questDescription;
    }
    
    public void Show()
    {
        Debug.Log("GetItem" + QuestTitle + "\n" + QuestDescription);
    }
}


public class BossMonsterHunting : IComposite
{
    private string QuestTitle;
    private string QuestDescription;


    public BossMonsterHunting(string questTitle, string questDescription)
    {
        QuestTitle = questTitle;
        QuestDescription = questDescription;
    }
    
    public void Show()
    {
        Debug.Log("BossMonsterHunting" + QuestTitle + "\n" + QuestDescription);
    }
}


