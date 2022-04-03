using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersData : MonoBehaviour
{
    public List<PlayersOptions> PlayersOptionsList;

    public override string ToString()
    {
        string result = "";
        PlayersOptionsList.ForEach(o =>
        {
            result += o.ToString();
        });
        return result;
    }
}
[System.Serializable]
public class PlayersOptions
{
    public string Name;
    public string Score;
    public string Country;

    public override string ToString()
    {
        return $"Name {Name} \nScore {Score} \nCountry {Country}";
    }
}