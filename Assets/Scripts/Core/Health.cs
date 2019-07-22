using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        bool isAlive = true;

        public bool IsAlive()
        {
            return isAlive;
        }
        public void TakeDamage(float damage)
        {
            float calculatedHealth = healthPoints - damage;
            healthPoints = (calculatedHealth > 0) ? calculatedHealth:0f;
            print(healthPoints);
            
            if (healthPoints <= 0f && isAlive)
            {
                Die();
            } 
        }

        public void Die()
        {
            if (!isAlive) return;
            GetComponent<Animator>().SetTrigger("die");
            isAlive = false;
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}