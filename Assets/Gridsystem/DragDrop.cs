using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public bool snapToGrid = true;

    void Update()
    {
        if ( isBeingHeld )
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            if (snapToGrid)
            {
                transform.position = new Vector3(Mathf.RoundToInt(mousePos.x - startPosX), Mathf.RoundToInt(mousePos.y - startPosY), 0);
            }
        }
    }

    private void OnMouseDown()

    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);


            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;

        }
    }

    private void OnMouseUp() {
        isBeingHeld = false;
    } 

}
