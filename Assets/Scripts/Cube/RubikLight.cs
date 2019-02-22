using System.Collections;
using System.Collections.Generic;
using Cube;
using UnityEngine;

public class RubikLight : MonoBehaviour
{
    [SerializeField] private GameObject blackCube;
    [SerializeField] private RubikCube cube;

    private bool solved, solving;

    void Update()
    {
        // return black cube if cube is solved
        if (solving && cube.checkCorrect())
        {
            blackCube.SetActive(true);
            solving = false;
            solved = true;
        }
    }
    
    public void onClick()
    {
        // solve cube on click (delete black cube for realistic picture)
        if (!solved && !solving)
        {
            blackCube.SetActive(false);
            solving = true;
            cube.animatedFix();
        }
    }
}
