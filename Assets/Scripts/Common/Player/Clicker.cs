﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{   
    
    [SerializeField] private float maxDistance = 100;
    [SerializeField] private GameObject camera;

    private GameObject selected  = null;
    
    // Update is called once per frame
    void Update ()
    {
        // get front object
        GameObject obj = rayCast();
        
        // calculate distance
        float dist = Vector3.Distance(transform.position, obj.transform.position);
        
        // invoke methods for selected objects
        reSelect(obj, dist);
        
        // invoke click on click
        if (Input.GetMouseButtonUp(0) && obj)
        {
            Clickable clickable = obj.GetComponent<Clickable>();
            if(clickable && clickable.getDist()>=dist)
                clickable.click();
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
    
    

    private GameObject rayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, maxDistance))
            return hit.collider.gameObject;

        return null;
    }
}
