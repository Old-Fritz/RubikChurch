using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Common.PlayerComps;
using UnityEngine;
using Random = UnityEngine.Random;

public class JumpCubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float maxRadius;
    [SerializeField] private float height;
    [SerializeField] private int count;

    private List<GameObject> cubesPool;
    
    // Start is called before the first frame update
    void Start()
    {
        cubesPool = new List<GameObject>(count);
        // create pool
        for (int i = 0; i < count; i++)
        {
            GameObject cube = Instantiate(cubePrefab, transform);
            placeCube(cube, transform.position);
            cubesPool.Add(cube);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = Player.main.transform.position;
        
        foreach (GameObject cube in cubesPool)
        {
            if(!checkCube(cube, center))
                placeCube(cube, center);
        }
    }

    private bool checkCube(GameObject cube, Vector3 center)
    {
        center.y = cube.transform.position.y;
        if (Vector3.Distance(center, cube.transform.position) > maxRadius)
            return false;
        return true;
    }

    private void placeCube(GameObject cube,Vector3 center)
    {
        // Generate position in square
        Vector3 newPosition;
        newPosition.x = Random.Range(-maxRadius, maxRadius);
        newPosition.y = height;
        newPosition.z = Random.Range(-maxRadius, maxRadius);

        // set position against player
        cube.transform.position = newPosition + center;
    }
}
