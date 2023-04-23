using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObject;


    private Vector3 pos;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public float gridSize;
    bool gridOn = true;
    [SerializeField] private Toggle gridToggle;


    private void Update()
    {
        if ( pendingObject != null )
        {
            if (gridOn)
            {
                pendingObject.transform.position = pos;
                RoundToNearestGrid(pos.x);
                RoundToNearestGrid(pos.y);
                RoundToNearestGrid(pos.z);
            }

            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceObject();
                }
            }
           
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
    }

    public void PlaceObject()
    {
        pendingObject = null;
        // eventually will minus money from player after placing object
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            gridOn = true;
        }
    }

    float RoundToNearestGrid(float pos)
    {
        float difference = pos % gridSize;
        pos -= difference;

        if ( difference > ( gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }

}
