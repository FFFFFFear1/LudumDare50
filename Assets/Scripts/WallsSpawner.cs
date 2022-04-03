using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WallsSpawner : MonoBehaviour
{
    private const int WALL_LENGTH = 30;

    [SerializeField] private WallView[] _wallViews;
    [SerializeField] private int _oneVariantWallAmount = 6;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private int _shownWallsAmount;
    private List<WallView> _walls = new List<WallView>();
    private List<WallView> _visibleWalls = new List<WallView>();
    private bool _wallsCreated;
    void Awake()
    {
        CreateWalls(); 
        ActivateFirstWalls();
    }

    private void CreateWalls()
    {
        for (int i = 0; i < _wallViews.Length; i++)
        {
            for (int j = 0; j < _oneVariantWallAmount; j++)
            {
                WallView wallVariant = Instantiate(_wallViews[i], transform);
                wallVariant.transform.parent = transform;
                if (_visibleWalls.Count < _shownWallsAmount)
                    _visibleWalls.Add(wallVariant);
                else
                    _walls.Add(wallVariant);
                wallVariant.gameObject.SetActive(false);
            }
        }
        _wallsCreated = true;
    }
    private void ActivateFirstWalls()
    {
        for (int i = 0; i < _visibleWalls.Count; i++)
        {
            if (i == 0)
                _visibleWalls[i].transform.position = transform.position;
            else
                _visibleWalls[i].transform.position = _visibleWalls[i - 1].DownWallPosition.position;
            _visibleWalls[i].gameObject.SetActive(true);
        }
    }
    private void SetWallsPosition()
    {
        if (_playerPosition.position.y < _visibleWalls[_shownWallsAmount/2].TopWallPosition.position.y )
        {
            _visibleWalls[0].gameObject.SetActive(false);
            _walls.Add(_visibleWalls[0]);
            _visibleWalls.Remove(_visibleWalls[0]);
            _visibleWalls.Add(GetRandomWall());
        }
    }

    private WallView GetRandomWall()
    {
        WallView wall = _walls[0];
        wall.transform.position = _visibleWalls[_visibleWalls.Count - 1].DownWallPosition.position;
        wall.gameObject.SetActive(true);
        _walls.Remove(wall);
        return wall;
    }
    void Update()
    {
        if(_wallsCreated)
        SetWallsPosition();
    }
}
