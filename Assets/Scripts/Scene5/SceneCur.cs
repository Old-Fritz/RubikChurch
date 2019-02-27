using Common.Managers;
using UnityEngine;

namespace Scene5
{
    public class SceneCur : MonoBehaviour
    {
        void Start()
        {
            // unload scenes
            Scenes.unLoadScene(4);
            Scenes.unLoadScene(6);
            Scenes.loadScene(9);
        }
    }
}
