using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RubikCube : MonoBehaviour
{

    [SerializeField] private GameObject face;
    [SerializeField] private float animationSpeed;

    private Quaternion faceTarget;
    private bool isRotation;
    private List<GameObject> faceParts;
    private String genStr;

    void Start()
    {
        generate(20);
        animatedFix();
    }
    
    void Update()
    {
        if (isRotation)
        {
            face.transform.localRotation = Quaternion.RotateTowards(face.transform.localRotation, faceTarget, Time.deltaTime*animationSpeed);
            if (face.transform.localRotation == faceTarget)
                stopRotation();
        }
       
    }

    public void generate(int moves)
    {
        genStr = "";
        
        for (int i = 0; i < moves; i++)
        {
            int nextMove = Random.RandomRange(0, 9);
            switch (nextMove)
            {
                case 0:
                    genStr += "L";
                    break;
                case 1:
                    genStr += "R";
                    break;
                case 2:
                    genStr += "U";
                    break;
                case 3:
                    genStr += "D";
                    break;
                case 4:
                    genStr += "F";
                    break;
                case 5:
                    genStr += "L\'";
                    break;
                case 6:
                    genStr += "R\'";
                    break;
                case 7:
                    genStr += "D\'";
                    break;
                case 8:
                    genStr += "U\'";
                    break;
                case 9:
                    genStr += "F\'";
                    break;
            }
        }
        
        move(genStr);
    }

    public void animatedFix()
    {
        StartCoroutine(animatedFixCor());
    }
    
    public void move(String rotateStr)
    {
        for (int i = 0; i < rotateStr.Length; i++)
        {
            char letter = Char.ToUpper(rotateStr[i]);
            // skip incorrect letter
            if("LRUDF".IndexOf(letter)<0)
                continue;
            // check revert
            bool revert = false;
            if (i < rotateStr.Length - 1 && (rotateStr[i + 1] == '\'' || rotateStr[i + 1] == '`'))
            {
                revert = true;
                i++;
            }
            
            // make move
            if(isRotation)
                stopRotation();
            switch (letter)
            {
                case 'L':
                    moveL(revert);
                    break;
                case 'R':
                    moveR(revert);
                    break;
                case 'U':
                    moveU(revert);
                    break;
                case 'D':
                    moveD(revert);
                    break;
                case 'F':
                    moveF(revert);
                    break;
            }

        }
        
    }
    
    private void moveL(bool revert = false)
    {
        List<GameObject> parts = getObjects(-1, 0, 0);
        float angle = 90;
        if (revert)
            angle *= -1;
        rotateFace(parts, angle,0,0);
        
    }
    
    private void moveR(bool revert = false)
    {
        List<GameObject> parts = getObjects(1, 0, 0);
        float angle = 90;
        if (revert)
            angle *= -1;
        rotateFace(parts, angle,0,0);
    }
    
    private void moveU(bool revert = false)
    {
        List<GameObject> parts = getObjects(0, 1, 0);
        float angle = 90;
        if (revert)
            angle *= -1;
        rotateFace(parts, 0,angle,0);
    }
    
    private void moveD(bool revert = false)
    {
        List<GameObject> parts = getObjects(0, -1, 0);
        float angle = 90;
        if (revert)
            angle *= -1;
        rotateFace(parts, 0,angle,0);
    }
    
    private void moveF(bool revert = false)
    {
        List<GameObject> parts = getObjects(0, 0, -1);
        float angle = 90;
        if (revert)
            angle *= -1;
        rotateFace(parts, 0,0,angle);
    }
    
    private bool checkObject(GameObject obj, int x, int y, int z)
    {
        // check if object in one space with x,y,z
        Vector3 pos = obj.transform.localPosition;
        if (x > 0 && pos.x <= 0)
            return false;
        if (x < 0 && pos.x >= 0)
            return false;
        
        if (y > 0 && pos.y <= 0)
            return false;
        if (y < 0 && pos.y >= 0)
            return false;
        
        if (z > 0 && pos.z <= 0)
            return false;
        if (z < 0 && pos.z >= 0)
            return false;

        return true;
    }

    private void normalizeTransform(GameObject obj)
    {
		// remove extra numbers after comma
	
        Vector3 rot = obj.transform.localRotation.eulerAngles;
        rot.x = Mathf.Round(rot.x);
        rot.y = Mathf.Round(rot.y);
        rot.z = Mathf.Round(rot.z);
        obj.transform.localRotation = Quaternion.Euler(rot);
        
        obj.transform.localScale = new Vector3(1,1,1);
        
        Vector3 pos = obj.transform.localPosition;
        pos.x = Mathf.Round(pos.x*10000)/10000;
		pos.y = Mathf.Round(pos.y*10000)/10000;
		pos.z = Mathf.Round(pos.z*10000)/10000;

        obj.transform.localPosition = pos;
        
    }

    private List<GameObject> getObjects(int x, int y, int z)
    {
        List<GameObject> objects = new List<GameObject>();
        foreach (Transform obj in transform)
        {
            CubePart part = obj.gameObject.GetComponent<CubePart>();
            if (part && checkObject(obj.gameObject, x, y, z))
                objects.Add(obj.gameObject);
        }

        return objects;
    }

    private void addToFace(List<GameObject> parts)
    {
        foreach (GameObject part in parts)
        {
            part.transform.parent = face.transform;
        }
    }

    private void removeFromFace(List<GameObject> parts)
    {
        foreach (GameObject part in parts)
        {
            part.transform.parent = transform;
        }
        
        face.transform.localRotation = Quaternion.identity;
    }
    
    private void rotateFace(List<GameObject> parts, float x, float y, float z)
    {
        
        addToFace(parts);
        faceParts = parts;
        
        Quaternion rotateX = Quaternion.AngleAxis(x,Vector3.left);
        Quaternion rotateY = Quaternion.AngleAxis(y,Vector3.up);
        Quaternion rotateZ = Quaternion.AngleAxis(z,Vector3.forward);
        faceTarget = face.transform.localRotation * rotateZ * rotateY * rotateX;
        
        isRotation = true;
    }

    private void stopRotation()
    {
        isRotation = false;
        face.transform.localRotation = faceTarget;
        removeFromFace(faceParts);
        foreach (GameObject obj in faceParts)
        {
            normalizeTransform(obj);
        }
        faceParts.Clear();
    }

    private IEnumerator animatedFixCor()
    {
        for (int i = genStr.Length - 1; i >= 0; i--)
        {
            char letter = genStr[i];
            bool revert = true;
            if (letter == '\'' || letter == '`')
            {
                revert = false;
                letter = genStr[--i];
            }

            String moveStr = "";
            moveStr += letter;
            if (revert)
                moveStr += "\'";
            move(moveStr);
            yield return new WaitForSeconds(90/animationSpeed);
        }
    }
}
