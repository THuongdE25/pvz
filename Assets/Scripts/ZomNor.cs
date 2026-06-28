using UnityEngine;

    public enum HatType
    {
        None, Hat1, Hat2
    }
public class ZomNor : Zombies
{
    [SerializeField] private HatType hatType;
    [SerializeField] private GameObject Hat1;
    [SerializeField] private GameObject Hat2;
    [SerializeField]private float hatHealth;
    protected override void Start()
    {
        base.Start();

        switch (hatType)
        {
            case HatType.None:
                hatHealth = 0;
                Hat1.SetActive(false);
                Hat2.SetActive(false);
                break;

            case HatType.Hat1:
                Hat1.SetActive(true);
                Hat2.SetActive(false);
                hatHealth = 100;
                break;

            case HatType.Hat2:
                Hat1.SetActive(false);
                Hat2.SetActive(true);
                hatHealth = 300;
                break;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (hatHealth > 0)
        {
            if (damage >= hatHealth)
            {
                float remainDamage = damage - hatHealth;
                hatHealth = 0;
                Hat1.SetActive(false);
                Hat2.SetActive(false);
                currenthealth -= remainDamage;
            }
            else
            {
                hatHealth -= damage;
            }
        }
        else
        {
            base.TakeDamage(damage);
        }
    }
}
