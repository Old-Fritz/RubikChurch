using Common.PlayerComps;
using Cube;
using UnityEngine;

namespace Scene6
{
    public class MegaCube : MonoBehaviour
    {
        [SerializeField] private RubikCube cube;

        private bool falled;
        private bool startSolve = false;
   
        void Update()
        {
            if (!startSolve && cube.isCreated())
            {
                cube.animatedFix();
                startSolve = true;
            }
            // fall after correct
            if (startSolve && cube.checkCorrect())
            {
                Rigidbody rigid = cube.gameObject.GetComponent<Rigidbody>();
                if (rigid)
                    rigid.useGravity = true;
            }
        }
    }
}
