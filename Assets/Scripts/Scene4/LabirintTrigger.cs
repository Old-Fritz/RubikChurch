using Common.PlayerComps;
using UnityEngine;

namespace Scene4
{
    public class LabirintTrigger : MonoBehaviour
    {
        public void onClick()
        {
            // turn on effects
            EffectsController effects = Player.main.GetComponent<EffectsController>();
            if(effects)
                effects.setEffectsActive(true);
        }
    }
}
