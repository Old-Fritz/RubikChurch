using Common.Managers;
using UnityEngine;

namespace Scene4
{
    public class SceneCur : MonoBehaviour
    {
        [SerializeField] private AudioClip soundtrack;
        
        void Start()
        {
            // preload scenes
            Scenes.unLoadScene(3);
            Scenes.loadScene(5);
            Scenes.loadScene(6);
        }

        private void OnEnable()
        {
            Music.set(soundtrack);
        }
    }
}
