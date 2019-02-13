using System.Collections;
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
        if (!obj)
            return;
        
        // invoke methods for selected objects
        reSelect(obj);
        
        // invoke click on click
        if (Input.GetMouseButtonUp(0))
        {
            Clickable clickable = obj.GetComponent<Clickable>();
            if(clickable)
                clickable.click();
        }
    }

    private void reSelect(GameObject newSelected)
    {
        if (!selected || selected != newSelected)
        {
            // check for selectable and invoke methods

            if (selected)
            {
                Selectable selectComp = selected.GetComponent<Selectable>();
                if(selectComp)
                    selectComp.unSelect();
            }
            
            Selectable newSelectComp = newSelected.GetComponent<Selectable>();
            
            if (newSelectComp)
                newSelectComp.select();
            
            selected = newSelected;
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
