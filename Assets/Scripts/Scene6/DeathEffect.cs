using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scene6
{
    public class DeathEffect : MonoBehaviour
    {
        [SerializeField] private UnityEvent afterDeath;
        [SerializeField] private float deathTime;
        [SerializeField] private Image image;

        private static int deathColliders = 0;

        void Update()
        {
            // change effect to end or to start
            Color color = image.color;
            if (deathColliders > 0)
                color.a += Time.deltaTime * deathTime;
            else if(color.a>0)
                color.a -= Time.deltaTime * deathTime;

            image.color = color;
        
            // invoke death action in end of effect
            if(color.a >=1)
                afterDeath.Invoke();
        }
    
        public static void startDeath()
        {
            deathColliders++;
        }

        public static void endDeath()
        {
            deathColliders--;
        }
    }
}
