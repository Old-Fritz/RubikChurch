using Common.PlayerComps;
using UnityEngine;

namespace Common.Properties
{
    public class Final : MonoBehaviour
    {
        [SerializeField] private float time;
        [SerializeField] private Finaling.End end;

        public void startFinal()
        {
            Finaling finaling = Player.main.gameObject.GetComponent<Finaling>();
            if(finaling)
                finaling.startFinal(time, end);
        }
    }
}
