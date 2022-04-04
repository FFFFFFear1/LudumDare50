using System.Collections.Generic;
using UnityEngine;

public class BonusView : MonoBehaviour
{
    [SerializeField] private BonusType bonus;
    private Dictionary<BonusType, ABonus> bonuses;
    private int appearChance = 20;
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
            bonuses[bonus].UseBounus(collision.transform.GetComponent<Player>());
        }
    }
}
public class HealBonus : ABonus
{
    private int _healPower=20;

    public HealBonus(GameObject bonus) : base(bonus)
    {
    }

    public override void UseBounus(Player player)
    {
        base.UseBounus(player);
        player.HP += _healPower;
    }
}
public abstract class ABonus
{
    protected GameObject _bonus;

    protected ABonus(GameObject bonus)
    {
        _bonus = bonus;
    }

    public virtual void UseBounus(Player player)
    {
        _bonus.SetActive(false);
    }

}