using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    private GameObject selectedBuilding;
    //Raycasts at the current mouse position after a mouse click, if a building is detected, enable the UI for that building
    //If no building is detected disable the UI for the currently selected building
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            if (Physics.Raycast(ray, out hitData)) {
                if (hitData.transform.CompareTag("Building")) {
                    //If a building is already selected, disable UI for that building
                    if (selectedBuilding) {
                        selectedBuilding.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    selectedBuilding = hitData.transform.gameObject;
                    selectedBuilding.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            else {
                //Check if the mouse click occurred over a UI element (prevent building UI from disabling on clicking a UI element)
                if (!isOverUI) {
                    selectedBuilding.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
