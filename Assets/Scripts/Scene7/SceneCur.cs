using Common.Managers;
using Common.PlayerComps;
using Common.Properties;
using UnityEngine;

namespace Scene7
{
    public class SceneCur : MonoBehaviour
    {
        [SerializeField] private ClickMovable bus;
        
        void Start()
        {
            // player can't move and  without effects
            Move move = Player.main.GetComponent<Move>();
            if (move)
                move.moveAccepted = false;

            EffectsController effects = Player.main.GetComponent<EffectsController>();
            if (effects)
                effects.setEffectsActive(false);
            
            // run bus
            if(bus)
                bus.move();
            
            // unload scenes
            Scenes.unLoadScene(6);
            Scenes.unLoadScene(8);
            Scenes.loadScene(9);
        }
        
    }
}
