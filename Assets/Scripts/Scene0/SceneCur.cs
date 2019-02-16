using Common.Player;
using UnityEngine;

namespace Scene0
{
    public class SceneCur : MonoBehaviour
    {
        public bool cubeUp { get; set; }

        void Start()
        {
            Move playerMove = Player.main.GetComponent<Move>();
            if (playerMove)
                playerMove.moveAccepted = false;
        }
    }
}