using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingUI : MonoBehaviour
{
    private Building building;
    private BuildingResourceGen buildingGenerator;
    //Link script to destroy and collect buttons
    private void OnEnable() {
        building = GetComponentInParent<Building>();
        buildingGenerator = GetComponentInParent<BuildingResourceGen>();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button destroyButton = root.Q<Button>("destroyButton");
        Button collectButton = root.Q<Button>("collectButton");

        destroyButton.clicked += () => 
        {
            building.Destroy();
            Debug.Log("Buidling Destroyed");
        }; 

        collectButton.clicked += () => 
        {
            buildingGenerator.Collect();
            Debug.Log("Resources Collected");
        }; 
    }
}
