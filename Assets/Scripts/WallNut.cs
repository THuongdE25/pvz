using UnityEngine;

public class WallNut : Plants
{
    [SerializeField] private Sprite healthySprite;
    [SerializeField] private Sprite crackedSprite;

    private SpriteRenderer sr;

    protected override void Start()
    {
        base.Start();
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }
     public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UpdateSprite();
    }

    void UpdateSprite()
    {
        float healthPercent = (float)currenthealth / maxhealth;

        if (healthPercent <= 0.5f)
        {
            sr.sprite = crackedSprite;
        }else
        {
            sr.sprite = healthySprite;
        }
    }
}