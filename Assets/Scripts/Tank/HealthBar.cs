using TMPro;
using UnityEngine;

/* Health Bar for Tank */

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    [SerializeField] private TextMeshProUGUI healthText;

    public void ChangeHealth(int change)
    {
        healthText.text = "Health : " + change;
    }
}
