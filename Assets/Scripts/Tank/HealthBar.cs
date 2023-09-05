using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    [SerializeField] private TextMeshProUGUI healthText;

    public void ChangeHealth(int change)
    {
        healthText.text = "Health : " + change;
    }
}
