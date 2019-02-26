using Common.PlayerComps;
using Cube;
using UnityEngine;

namespace Scene6
{
    public class MegaCube : MonoBehaviour
    {
        [SerializeField] private RubikCube cube;

        private bool falled;
    
        void Start()
        {
            cube.animatedFix();
        }

        void Update()
        {
            // fall after correct
            if (cube.checkCorrect())
            {
                Rigidbody rigid = cube.gameObject.GetComponent<Rigidbody>();
                if (rigid)
                    rigid.useGravity = true;
            }
        }
    }
}
