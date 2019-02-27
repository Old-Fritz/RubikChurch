using Common.Managers;
using UnityEngine;

namespace Scene8
{
    public class SceneCur : MonoBehaviour
    {
        void Start()
        {
            // unload scene
            Scenes.unLoadScene(6);
            Scenes.unLoadScene(7);
            Scenes.loadScene(9);
        }
    }
}
