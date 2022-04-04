using System.Collections.Generic;
using UnityEngine;

public class BonusView : MonoBehaviour
{
    [SerializeField] private BonusType bonus;
    private Dictionary<BonusType, ABonus> bonuses;
    [SerializeField] private int appearChance = 20;
    [SerializeField] private int power = 20;
    public int AppearChance { get => appearChance;}

    private void Awake()
    {
        bonuses = new Dictionary<BonusType, ABonus>()
    {
        {BonusType.heal, new HealBonus(gameObject) },
        {BonusType.speed, new HealBonus(gameObject) },
        {BonusType.slow, new HealBonus(gameObject) },
    };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Player>())
        {
            bonuses[bonus].UseBounus(collision.transform.GetComponent<Player>(),power);
        }
    }
}
public class HealBonus : ABonus
{
    public HealBonus(GameObject bonus) : base(bonus)
    {
    }

    public override void UseBounus(Player player, float power)
    {
        base.UseBounus(player,power);
        player.HP += power;
    }
}
public abstract class ABonus
{
    protected GameObject _bonus;

    protected ABonus(GameObject bonus)
    {
        _bonus = bonus;
    }

    public virtual void UseBounus(Player player, float power)
    {
        _bonus.SetActive(false);
    }

}