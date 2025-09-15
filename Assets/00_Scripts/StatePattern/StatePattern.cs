using Unity.VisualScripting;
using UnityEngine;


public interface IState
{
    void Input(Player player, string input);
    void Update(Player player);
}
public class IDLE_State : IState
{
    public void Input(Player player, string input) //1번 업뎃
    {
        player.AnimatiorChange("isIDLE");
    }

    public void Update(Player player)// 업뎃 변경
    {
        
    }
}

public class RUN_State : IState
{
    public void Input(Player player, string input) //1번 업뎃
    {
        
    }


   
    public void Update(Player player)// 업뎃 변경
    {
        player.transform.Translate(new Vector3(1 * Time.deltaTime * 10.0f , 0, 0));
        player.AnimatiorChange("isRUN");
    }
}