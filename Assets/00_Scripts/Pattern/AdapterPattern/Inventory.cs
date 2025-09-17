using UnityEngine;

public class Inventory : MonoBehaviour
{
    private IAdapter adapter_On;

    public GameObject HorizontalObj;
    public GameObject VerticalObj;
    void Start()
    {
        ChangeHorizontal();
        
        adapter_On.OnInventory(this);   
    }

    void ChangeHorizontal()
    {
        adapter_On = new HorizontalPattern();
    }

    void ChangeVertical()
    {
        adapter_On = new VerticalPattern();
    }
}


