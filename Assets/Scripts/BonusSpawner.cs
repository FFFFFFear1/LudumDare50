using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] bonusesSpawnPositions;
    private List<BonusView> _bonuses = new List<BonusView>();
    private int _bonusesAmount = 3;
    void Start()
    {
        CreateBonuses();
        SetBonusesPositions();
    }
    private void SetBonusesPositions()
    {
        for (int i = 0; i < bonusesSpawnPositions.Length; i++)
        {
            int random = Random.Range(0, _bonuses.Count);
            if(_bonuses[random].AppearChance >= Random.Range(0, 101))
            {
                _bonuses[random].gameObject.SetActive(true);
                _bonuses[random].transform.position = bonusesSpawnPositions[i].transform.position;
            }
        }
    }
    private void CreateBonuses()
    {
        BonusView[] bonuses = Resources.LoadAll<BonusView>("Bonuses");
        for (int j = 0; j < bonuses.Length; j++)
        {
            for (int i = 0; i < _bonusesAmount; i++)
            {
                _bonuses.Add(Instantiate(bonuses[j], transform));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
