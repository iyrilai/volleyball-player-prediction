using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Data
{
    public List<Player> players = new();
    //readonly string savePath = ;
    readonly string dataPath = Path.Combine(Application.streamingAssetsPath, "player.dat");

    public void Init()
    {
        if (File.Exists(dataPath))
        {
            var data = File.ReadAllText(dataPath);
            players = JsonConvert.DeserializeObject<List<Player>>(data);
            return;
        }
    }

    public void Save()
    {
        if(!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);
        

        var data = JsonConvert.SerializeObject(players);
        File.WriteAllText(dataPath, data);
    }

    public bool IsPlayerThere(int id)
    {
        foreach (var player in players) 
        { 
            if(player.ID == id) return true;
        }

        return false;
    }

    public Player GetPlayer(int id)
    {
        foreach (var player in players)
        {
            if (player.ID == id) return player;
        }

        return players[0];
    }

    public void CreatePlayer(int id, string name, int matchs, int sp, int dp, int ap)
    {
        var player = new Player(name, id, matchs, sp, dp, ap);
        players.Add(player);
        Save();
    }
}