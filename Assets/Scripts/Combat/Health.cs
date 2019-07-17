using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;

        public void TakeDamage(float damage)
        {
            float calculatedHealth = health - damage;
            health = (calculatedHealth > 0) ? calculatedHealth:0f;
            print(health);
        }
    }
}