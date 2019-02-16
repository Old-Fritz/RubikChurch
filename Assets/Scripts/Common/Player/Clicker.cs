using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{   
    
    [SerializeField] private float maxDistance = 100;
    [SerializeField] private GameObject camera;
    [SerializeField] private float pushForse = 1000;

    private GameObject selected  = null;
    private Draggable dragged = null;
    
    // Update is called once per frame
    void Update ()
    {
        if (Interface.main.notesShowed)
            return;
        // perform drag
        performDrag();
        
        // get front object
        GameObject obj = rayCast();
        
        // calculate distance
        float dist = 0;
        if(obj)
            dist = Vector3.Distance(transform.position, obj.transform.position);
        
        // invoke methods for selected objects
        reSelect(obj, dist);
        
        // invoke click on click
        if (Input.GetMouseButtonUp(0) && obj)
        {
            click(obj, dist);
            checkDrag(obj, dist);
        }

        if (Input.GetMouseButtonUp(1) && obj)
        {
            pushDrag();
        }
    }

    private void reSelect(GameObject newSelected, float dist)
    {
        
        // reselect if has been choosen another object
        if (selected != newSelected)
        {
            // clear old description
            Interface.main.changeDescription("");
            
            // check for selectable and invoke methods
            if (selected)
            {
                Selectable selectComp = selected.GetComponent<Selectable>();
                if(selectComp)
                    selectComp.unSelect();
            }

            if (newSelected)
            {
                Selectable newSelectComp = newSelected.GetComponent<Selectable>();

                if (newSelectComp && newSelectComp.getDist() >= dist)
                {
                    newSelectComp.select();
                    selected = newSelected;
                }
                else
                {
                    selected = null;
                }
            }
           
        }
        // unselect if distance is too big
        else if (selected)
        {
            Selectable selectComp = selected.GetComponent<Selectable>();
            if (selectComp && selectComp.getDist() < dist)
            {
                selectComp.unSelect();
                selected = null;
            }
        }
        
    }

    private void click(GameObject clicked, float dist)
    {
        Clickable clickable = clicked.GetComponent<Clickable>();
        if(clickable && clickable.getDist()>=dist)
            clickable.click();
    }

    private void checkDrag(GameObject drag,  float dist)
    {
        // undrag object
        if (dragged)
        {
            dragged.endDrag();
            dragged = null;
        }
        else
        {
            Draggable dragComp = drag.GetComponent<Draggable>();
            if (dragComp && dragComp.getStartDist()>=dist)
            {
                dragged = dragComp;
                dragged.startDrag();
                dragged.transform.parent = camera.transform;
            }
        }
    }

    private void pushDrag()
    {
        if (dragged)
        {
            dragged.endDrag();
            dragged.push(camera.transform.TransformDirection(Vector3.forward)*pushForse);
            dragged = null;
        }
    }

    private void performDrag()
    {
        if (dragged)
        {
            // calculate position from player
            Vector3 position = Vector3.forward * dragged.getWorkDist();
            
            // set position in front of camera
            dragged.transform.localPosition = Vector3.MoveTowards(dragged.transform.localPosition, position, 5*Time.deltaTime);
        }
    }
    
    private GameObject rayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, maxDistance))
            return hit.collider.gameObject;

        return null;
    }
}
