using Common.Managers;
using UnityEngine;

namespace Scene4
{
    public class SceneCur : MonoBehaviour
    {
        void Start()
        {
            // preload scenes
            Scenes.unLoadScene(3);
            Scenes.loadScene(5);
            Scenes.loadScene(6);
        }
    }
}
