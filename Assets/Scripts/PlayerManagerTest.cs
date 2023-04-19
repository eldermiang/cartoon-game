using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerTest : MonoBehaviour
{
    private int elixirCapacity = 3000;
    private int goldCapacity = 3000;
    private int elixir = 0;
    private int gold = 0;
    //Add amount of resource to the player's current resource
    //Returns the amount of resources consumed (Returns 0 if resources are capped)
    public int AddElixir(int amount) {
        int amountUsed = amount;
        elixir += amount;
        //Resource overcap scenario
        if (elixir > elixirCapacity) {
            amountUsed -= elixir - elixirCapacity;
            if (amountUsed < 0) {
                amountUsed = 0;
            }
            //Set current resource to maximum resource
            elixir = elixirCapacity;
        }
        Debug.Log("Current player elixir: " + elixir);
        return amountUsed;
    }
    public void AddGold(int amount) {

    }
}
