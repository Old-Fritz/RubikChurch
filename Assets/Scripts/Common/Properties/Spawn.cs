using Common.PlayerComps;
using UnityEngine;

namespace Common.Properties
{
    public class Spawn : MonoBehaviour
    {
        public void spawn(GameObject player)
        {
            // set player transform params as in spawn
            player.transform.localPosition = transform.localPosition;
            player.transform.localRotation = transform.localRotation;
            player.GetComponent<MouseRotation>().setDefault();
        }
    }
}
