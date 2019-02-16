using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float speed;

    private bool _moveAccepted;
    public bool moveAccepted
    {
        get { return _moveAccepted; }
        set
        {
            _moveAccepted = value;

            CapsuleCollider collider = GetComponent<CapsuleCollider>();
            if (collider)
                collider.enabled = value;

            Rigidbody rigid = GetComponent<Rigidbody>();
            if (rigid)
                rigid.useGravity = value;
        }
    }

    void Start()
    {
        moveAccepted = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(moveAccepted)
            processInput();
    }

    private void processInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            move(Vector3.forward);
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            move(Vector3.left);
        
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            move(Vector3.back);
        
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            move(Vector3.right);
    }

    private void move(Vector3 vector)
    {
        Vector3 rotatedVector = Quaternion.AngleAxis(camera.transform.eulerAngles.y, Vector3.up) * vector;
        transform.position += rotatedVector * Time.deltaTime * speed;
    }
}
