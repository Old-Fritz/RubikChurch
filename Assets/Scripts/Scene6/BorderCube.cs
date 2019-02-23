using System.Collections;
using System.Collections.Generic;
using Cube;
using UnityEngine;

public class BorderCube : MonoBehaviour
{
    [SerializeField] private RubikCube cube;
    [SerializeField] private float minScale = 2;
    [SerializeField] private float maxScale = 15;
    [SerializeField] private float scaleSpeed = 1;
    [SerializeField] private float rotateSpeed = 30;

    private Vector3 targetScale;
    private Quaternion targetRotation;
    private bool solving, generated;

    void Start()
    {
        generateRotationTarget();
        generateScaleTarget();
    }
    
    void Update()
    {
        // update scale
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
        if(transform.localScale==targetScale)
            generateScaleTarget();
        
        // update rotation
        cube.transform.localRotation = Quaternion.RotateTowards(cube.transform.localRotation, targetRotation, Time.deltaTime * rotateSpeed);
        if(cube.transform.localRotation==targetRotation)
            generateRotationTarget();
    }

    private void generateScaleTarget()
    {
        targetScale.x = Random.Range(minScale, maxScale);
        targetScale.y = Random.Range(minScale, maxScale);
        targetScale.z = Random.Range(minScale, maxScale);
    }

    private void generateRotationTarget()
    {
        Vector3 angles;
        angles.x = Random.Range(-360, 360);
        angles.y = Random.Range(-360, 360);
        angles.z = Random.Range(-360, 360);
        
        targetRotation = Quaternion.Euler(angles);
    }
}
