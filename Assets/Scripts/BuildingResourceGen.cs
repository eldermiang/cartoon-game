using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingResourceGen : MonoBehaviour
{
    //Temporary values for testing
    private int GENERATE_DELAY = 1;
    private int resourceMaxCapacity = 3600;
    private int resourceCurrCapacity = 0;
    private int generatedAmount = 100;
    Coroutine generateCoroutine;
    private bool generateRunning = false;
    [SerializeField] private PlayerManagerTest player;
    [SerializeField] private Resource resourceType;
    public UnityEvent<Resource, int> onResourceQuantityChange;

    private void Update() {
        if (!generateRunning) {
            StopAllCoroutines();
            StartCoroutine(Generate());
        }
    }

    //Coroutine to generate resources every GENERATE_DELAY seconds
    //Infinitely loop until resourceCurrCapacity is equal to resourceMaxCapacity
    private IEnumerator Generate() {
        generateRunning = true;
        resourceCurrCapacity += generatedAmount;
        //Invoke resource quantity change event
        onResourceQuantityChange.Invoke(resourceType, resourceCurrCapacity);
        if (resourceCurrCapacity > resourceMaxCapacity) {
            resourceCurrCapacity = resourceMaxCapacity;
        }
        yield return new WaitForSeconds(GENERATE_DELAY);
        if (resourceCurrCapacity < resourceMaxCapacity) {
            StartCoroutine(Generate());
        }
        else {
            generateRunning = false;
        }
    }
    //Collect currently stored resources based on resourceType and add it to the player's resources
    public void Collect() {
        int amountUsed = player.AddResource(resourceCurrCapacity, resourceType);
        resourceCurrCapacity -= amountUsed;
        onResourceQuantityChange.Invoke(resourceType, resourceCurrCapacity);
    }
}
