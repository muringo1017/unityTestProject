using UnityEngine;

public interface IAdapter
{
    public void OnInventory(Inventory inventory)
    {
        
    }

}

public class HorizontalPattern : IAdapter
{

    public void OnInventory(Inventory inventory)
    {
        inventory.HorizontalObj.SetActive(true);
    }
    
}

public class VerticalPattern : IAdapter
{
    public void OnInventory(Inventory inventory)
    {
        inventory.VerticalObj.SetActive(true);
    }

}
