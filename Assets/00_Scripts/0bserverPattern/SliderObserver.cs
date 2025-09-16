using System;
using UnityEngine;
using UnityEngine.UI;
public class SliderObserver : MonoBehaviour, IObserver
{
  private Slider slider;

  private void Start()
  {
    slider = GetComponent<Slider>();
    ObserverPattern pattern = new ObserverPattern();
    pattern.Add(this);

    pattern.HP = 50;
    pattern.Change_HP();
  }

  public void Init(int hp)
  {
    slider.value = (float)hp / 100;
  }
}
