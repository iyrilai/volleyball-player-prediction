using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamSelection : MonoBehaviour
{
    [SerializeField] TMP_InputField[] teamA;
    [SerializeField] TMP_InputField[] teamB;

    [SerializeField] TMP_Text error;

    [SerializeField] TMP_Dropdown playerList;
   
    [SerializeField] OnMatch match;
    [SerializeField] UI ui;


    void OnEnable()
    {
        playerList.ClearOptions();
        foreach (var player in PlayerManager.Instance.Data.players)
        {
            playerList.options.Add(new($"{player.Name} - {player.ID}"));
        }

        if (PlayerManager.Instance.Data.players.Count < 12)
        {
            error.text = $"Total players is {PlayerManager.Instance.Data.players.Count}, Need 12 players to start match.";
            return;
        }

        error.text = string.Empty;   
    }

    public void Submit()
    {
        match.teamA.Clear();
        match.teamB.Clear();

        List<int> teamAID = new();
        List<int> teamBID = new();

        foreach (var a in teamA)
        {
            int id;
            id = int.Parse(a.text);
            foreach (var aID in teamAID)
            {
                if (aID == id)
                {
                    error.text = $"Dulicate ID found on number - {id}";
                    return;
                }         
            }

            teamAID.Add(id);
        }

        foreach (var b in teamB)
        {
            int id = int.Parse(b.text);
            foreach (var bID in teamBID)
            {
                if (bID == id)
                {
                    error.text = $"Dulicate ID found on number - {id}";
                    return;
                }          
            }

            teamBID.Add(id);
        }

        foreach (var a in teamAID)
            match.teamA.Add(PlayerManager.Instance.Data.GetPlayer(a));

        foreach (var b in teamBID)
            match.teamB.Add(PlayerManager.Instance.Data.GetPlayer(b));

        ui.LoadScene(UI.Scene.StartMatch);
        match.MatchStart();
    }
}
