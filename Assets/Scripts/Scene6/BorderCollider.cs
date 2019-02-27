using Common.PlayerComps;
using Common.Properties;
using JetBrains.Annotations;
using UnityEngine;

namespace Scene6
{
    public class BorderCollider : MonoBehaviour
    {
        public void onClick()
        {
            // set end
            Save save = Player.main.GetComponent<Save>();
            if (save)
                save.currentEnd = Save.End.GOOD;
            
            // disable effects
            EffectsController effects = Player.main.GetComponent<EffectsController>();
            if (effects)
                effects.setEffectsActive(false);
        }
    }
}
