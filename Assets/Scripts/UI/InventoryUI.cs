using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private List<PlatfromUI> _platformsUI;

    [Space(10)]
    [Header("Game objects")]
    [SerializeField] private List<Platform> _platforms;

    public PlatfromUI _sprite;
    public static InventoryUI instance;

    private void Awake()
    {
        instance = this;
    }


    public PlatfromUI GetPlatfromSprite(PlatformType platformType)
    {
        foreach(PlatfromUI curPlatform in _platformsUI)
        {
            if(curPlatform.type.Equals(platformType))
            {

                var sprite = Instantiate(curPlatform.gameObject, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity, transform.parent);
                return sprite.GetComponent<PlatfromUI>();
            }
        }
        return null;
    }

    public GameObject GetPlatfrom(PlatformType platformType, Vector3 position, float angleZ)
    {
        foreach (Platform curPlatform in _platforms)
        {
            if (curPlatform.type.Equals(platformType))
            {
                var platform = Instantiate(curPlatform.gameObject, new Vector3(position.x, position.y), Quaternion.Euler(0, 0, angleZ));
                return platform;
            }
        }
        return null;
    }
}
