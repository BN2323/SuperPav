    using UnityEngine;
    using UnityEngine.UI;

    public class Healthbar : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;
        public bool isDead = false;

        public Slider healthSlider;

        void Start()
        {
            currentHealth = maxHealth;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            healthSlider.value = currentHealth;

            if (currentHealth <= 0)
                Die();
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            healthSlider.value = currentHealth;
        }

        public void Die()
        {
            isDead = true;
        }
    }
