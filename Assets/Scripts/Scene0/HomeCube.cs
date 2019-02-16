using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCube : MonoBehaviour
{
    [SerializeField] private GameObject note;

    [SerializeField] private String afterTouchDesc;
    [SerializeField] private String afterTouchSubs;
    [SerializeField] private String afterTakeDesc;
    [SerializeField] private String afterTakeSubs;

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float brokePower = 100;
    
    // states
    private bool touched, taken, moved, solved, solving;

    void Update()
    {
        if (solving)
        {
            RubikCube cube = GetComponent<RubikCube>();
            if (cube && cube.checkCorrect())
            {
                solving = false;
                solved = true;
                broke();
            }
        }
        if (taken && !moved)
        {
            transform.position = Vector3.MoveTowards(transform.position, note.transform.position,moveSpeed*Time.deltaTime);
            if (transform.position == note.transform.position)
                moved = true;
        }
    }
    
    public void onClick()
    {
        // change texts on first touch
        if (!touched)
        {
            Selectable select = GetComponent<Selectable>();
            if(select)
                select.setDesc(afterTouchDesc);
            Interface.main.showSubtitles(afterTouchSubs, 4);
            touched = true;
        }
        else if (!taken)
        {
            Selectable select = GetComponent<Selectable>();
            if(select)
                select.setDesc(afterTakeDesc);
            Interface.main.showSubtitles(afterTakeSubs, 3);
            taken = true;
        }
        else if (moved && !solving && !solved)
        {
            RubikCube cube = GetComponent<RubikCube>();
            if(cube)
                cube.animatedFix();
            solving = true;
        }
    }

    private void broke()
    {
        foreach (Transform part in transform)
        {
            if (part.CompareTag("CubePart"))
            {
                // add colliders and rigid to cube parts
                BoxCollider collider = part.gameObject.AddComponent<BoxCollider>();
                collider.size = new Vector3(0.1f, 0.1f, 0.1f);
                Rigidbody rigidbody = part.gameObject.AddComponent<Rigidbody>();
                rigidbody.useGravity = true;
                rigidbody.AddForce(part.transform.localPosition*brokePower);
            }
        }
        
        // hide cube collider
        BoxCollider cubeCollider = GetComponent<BoxCollider>();
        if (cubeCollider)
            cubeCollider.enabled = false;
        
        // show note
        note.SetActive(true);
    }
    
    
}
