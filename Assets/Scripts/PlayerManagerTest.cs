using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Public enum to handle referencing player resources
public enum Resource {
    Elixir,
    Gold
}
public class PlayerManagerTest : MonoBehaviour
{
    //Collections for storing player data
    Dictionary<Resource, int> maxCapacity = new Dictionary<Resource, int>();
    Dictionary<Resource, int> stats = new Dictionary<Resource, int>();
    //Add base values to the dictionary
    private void OnEnable() {
        maxCapacity.Add(Resource.Elixir, 1000);
        maxCapacity.Add(Resource.Gold, 1000);
        stats.Add(Resource.Elixir, 0);
        stats.Add(Resource.Gold, 0);
    }
    //Add amount of specified resource to the player's current specified resource
    //Returns the amount of resources consumed (Returns 0 if resources are capped)
    public int AddResource(int amount, Resource resourceType) {
        int amountUsed = amount;
        stats[resourceType] += amount;
        //Resource overflow scenario
        if (stats[resourceType] > maxCapacity[resourceType]) {
            amountUsed -= stats[resourceType] - maxCapacity[resourceType];
            if (amountUsed < 0) {
                amountUsed = 0;
            }
            stats[resourceType] = maxCapacity[resourceType];
        }
        Debug.Log($"Current player {resourceType}: {stats[resourceType]}");
        return amountUsed;
    }
}
