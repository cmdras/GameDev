using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;
        Vector3 guardPosition;

        private void Start() {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
            mover = GetComponent<Mover>();
            guardPosition = transform.position;
        }
        
        private void Update()
        {
            if(!health.IsAlive()) return;

            if(PlayerInRange(player) && fighter.CanAttack(player.gameObject))
            {
                fighter.Attack(player.gameObject);
            } 
            else
            {
                mover.StartMoveAction(guardPosition);
            }
        }

        private bool PlayerInRange(GameObject player)
        {
            return Vector3.Distance(transform.position, player.transform.position) < chaseDistance;
        }

        // called by Unity
        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
