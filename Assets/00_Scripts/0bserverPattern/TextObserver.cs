using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextObserver : MonoBehaviour, IObserver
{
    private TMP_Text text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        ObserverPattern pattern = new ObserverPattern();
        pattern.Add(this);

        pattern.HP = 50;
        pattern.Change_HP();
    }

    public void Init(int hp)
    {
        text.text = hp.ToString();
    }
}
