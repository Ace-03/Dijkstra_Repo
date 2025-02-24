using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    Vector3 mousePos;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }
}


/*
public class Drag : MonoBehaviour
{
    private float startPosX;
    private float startPosZ;

    [SerializeField]
    private bool triggerEnabled = true;

    public bool moving;

    void Update()
    {
        if (moving)
        {
            // set the object to the postion of the mouse
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.z - startPosZ);

            if (triggerEnabled)
            {
                // turns off boc collider
                GetComponent<BoxCollider>().enabled = false;

                // sets isHledObject to true

                //GetComponent<ElementBehaviour>().isHeldObject = true;

                triggerEnabled = false;
            }

        }
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // set the object to the postion of the mouse
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosZ = mousePos.z - this.transform.localPosition.z;

            moving = true;
        }
    }

    public void OnMouseUp()
    {
        //when mouse is released set moving to false, enable box collider, 
        Debug.Log("Mouse Button Released");
        moving = false;
        GetComponent<BoxCollider>().enabled = true;

        StartCoroutine(NotHeld()); // delays the activation of the NotHeld function

        triggerEnabled = true;
    }


    IEnumerator NotHeld()
    {
        // wait for 0.06 seconds before setting the isHeldObject flag to false
        // done to prevent flag from being set too early
        yield return new WaitForSeconds(0.06f);
        //triggerEnabled = true;
        // GetComponent<ElementBehaviour>().isHeldObject = false;
    }
}
*/