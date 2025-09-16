using UnityEngine;
using System.Collections.Generic;


public interface IObserver
{
    public void Init(int hp);
}

public interface ISubject
{
    void Add(IObserver observer);
    void Remove(IObserver observer);

    void Change_HP();
}
public class ObserverPattern : ISubject
{
   private int hp;
   private List<IObserver> _observers = new List<IObserver>();

   public int HP
   {
       get
       {
           return hp;
       }
       set
       {
           hp = value;
       }
   }

   public void Add(IObserver observer)
   {
       _observers.Add(observer);
   }
   
   public void Remove(IObserver observer)
   {
       _observers.Remove(observer);
   }

   public void Change_HP()
   {
       foreach (var observer in _observers)
       {
           observer.Init(HP);
       }
   }
}
