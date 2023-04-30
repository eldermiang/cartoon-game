using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera Cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    [SerializeField]
    private SpriteRenderer mapRenderer;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;




    private Vector3 dragOrigin;

    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }




    private void Update()
    {
        PanCamera();

    }



    private void PanCamera()
    {
        //save position of mouse in World space when drag starts (first time clicked)
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Cam.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(Input.mousePosition);
        }

        //Calculate distance between drag origin and new position if it is still held down
        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - Cam.ScreenToWorldPoint(Input.mousePosition);

            

            print("origin " + dragOrigin + " newPosition " + Cam.ScreenToWorldPoint(Input.mousePosition) + " =difference " + difference);

            //move the camera by that distance

            Cam.transform.position = Clampcamera(Cam.transform.position + difference);
           

        }
    }

    public void ZoomIn()
    {
        float newSize = Cam.orthographicSize - zoomStep;
        Cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Cam.transform.position = Clampcamera(Cam.transform.position);
    }
    public void ZoomOut()
    {
        float newSize = Cam.orthographicSize + zoomStep;
        Cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Cam.transform.position = Clampcamera(Cam.transform.position);
    }


    private Vector3 Clampcamera(Vector3 targetPosition)
    {
        float camHeight = Cam.orthographicSize;
        float camWidth = Cam.orthographicSize * Cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);

    }













}
