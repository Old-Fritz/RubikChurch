using System.Collections;
using System.Collections.Generic;
using Common.Properties;
using UnityEngine;

public class HiddenDoor : MonoBehaviour
{
    [SerializeField] private List<TriggerBox> triggers;
    [SerializeField] private float speed;

    private bool opening, opened;
    private Vector3 targetPos;
    
    void Update()
    {
        // open door if all triggers are correct
        if(!opening && !opened && checkTriggers())
            openDoor();
        else if (opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (transform.position == targetPos)
            {
                opened = true;
                opening = false;
            }
        }
    }

    private bool checkTriggers()
    {
        foreach (TriggerBox trigger in triggers)
        {
            if (!trigger.correct)
                return false;
        }

        return true;
    }

    private void openDoor()
    {            
        // set target pos
        float length = transform.localScale.y;
        targetPos = transform.position - new Vector3(0, length, 0);
    }
}
