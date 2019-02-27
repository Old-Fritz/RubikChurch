using Common.Managers;
using UnityEngine;

namespace Scene6
{
    public class SceneCur : MonoBehaviour
    {
        void Start()
        {
            // unload and preload correct scenes
            Scenes.unLoadScene(4);
            Scenes.unLoadScene(5);
            Scenes.loadScene(7);
            Scenes.loadScene(8);
        }
    }
}
