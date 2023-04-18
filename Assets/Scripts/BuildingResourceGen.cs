using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingResourceGen : MonoBehaviour
{
    //Temporary values for testing
    //resourceType likely to be subjected to change since strings are not the best option for a reference
    private int GENERATE_DELAY = 1;
    private string resourceType = "Elixir";
    private int resourceMaxCapacity = 3600;
    private int resourceCurrCapacity = 0;
    private int generatedAmount = 100;
    Coroutine generateCoroutine;
    private bool generateRunning = false;

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
        if (resourceCurrCapacity > resourceMaxCapacity) {
            resourceCurrCapacity = resourceMaxCapacity;
        }
        Debug.Log("Current elixir: " + resourceCurrCapacity);
        yield return new WaitForSeconds(GENERATE_DELAY);
        if (resourceCurrCapacity < resourceMaxCapacity) {
            StartCoroutine(Generate());
        }
        else {
            generateRunning = false;
        }
    }
    //Collect current resources and add it to the player's stash
    //Will have to figure out how to do this from a gameObject on click or compose into another element (button?)
    public void Collect() {

    }
}
