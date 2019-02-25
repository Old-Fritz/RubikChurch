using System.Collections.Generic;
using Common.PlayerComps;
using UnityEngine;

namespace Scene6
{
    public class BorderCubeManager : MonoBehaviour
    {
        [SerializeField] private float maxRadius = 60;
    
        private static List<BorderCube> cubes;
    
        void Update()
        {
            Vector3 center = Player.main.transform.position;
            foreach (BorderCube cube in cubes)
            {
           
                if (cube.gameObject.activeInHierarchy)
                {
                    // disactivate in long distance
                    if (Vector3.Distance(center, cube.transform.position) > maxRadius)
                        cube.gameObject.SetActive(false);
                    else
                        cube.updateTransform();
                }
                else if (Vector3.Distance(center, cube.transform.position) < maxRadius)
                {
                    cube.gameObject.SetActive(true);
                    cube.updateTransform();
                }
            }
        }
    
        public static void addCube(BorderCube cube)
        {
            if(cubes == null)
                cubes = new List<BorderCube>();
            cubes.Add(cube);
        }
    }
}
