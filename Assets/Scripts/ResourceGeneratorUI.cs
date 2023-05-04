using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceGeneratorUI : MonoBehaviour
{
    public void updateBuildingResourceCount(Resource resourceType, int resourceAmount) {
        this.transform.GetComponent<TMP_Text>().text = $"{resourceType}: {resourceAmount}";
    }
}
