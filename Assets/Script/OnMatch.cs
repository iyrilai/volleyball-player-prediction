using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class OnMatch : MonoBehaviour
{
    public List<Player> teamA = new();
    public List<Player> teamB = new();

    //UI
    [SerializeField] TMP_Text winner;
    [SerializeField] TMP_Text teamAPoint_text;
    [SerializeField] TMP_Text teamBPoint_text;
    [SerializeField] TMP_Text totalPoint_text;
    [SerializeField] TMP_Text teamAPer_text;
    [SerializeField] TMP_Text teamBPer_text;
    [SerializeField] Slider bar;

    int matchPoint = 25;
    int teamAPoint = 0;
    int teamBPoint = 0;

    int intenalAPoint = 1;
    int intenalBPoint = 1;

    bool isOver;

    public void MatchStart()
    {
        float avgA = 0.0f;
        float avgB = 0.0f;

        foreach (Player p in teamA) avgA += p.GetPoint();
        foreach (Player p in teamB) avgB += p.GetPoint();

        float diffent = Mathf.Abs(avgA - avgB);

        if (avgA > avgB) intenalAPoint += Mathf.RoundToInt(diffent);
        else intenalBPoint += Mathf.RoundToInt(diffent);

        UpdateUI();
    }

    public void AddPointA()
    {
        teamAPoint++;
        intenalAPoint++;

        UpdateUI();
    }

    public void AddPointB()
    {
        teamBPoint++;
        intenalBPoint++;

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (isOver) return;

        if(teamAPoint == teamBPoint && teamAPoint == matchPoint - 1) { matchPoint++; }

        var teamAWinningChanges = WinningCalulation();
        var teamBWinningChanges = 100 - teamAWinningChanges;

        teamAPoint_text.text = $"Points - {teamAPoint}";
        teamBPoint_text.text = $"Points - {teamBPoint}";
        totalPoint_text.text = $"TOTAL POINTS - {matchPoint}";

        teamAPer_text.text = $"{teamAWinningChanges:0.00}%";
        teamBPer_text.text = $"{teamBWinningChanges:0.00}%";

        bar.value = teamAWinningChanges;

        if (matchPoint <= teamAPoint)
        {
            winner.text = "Team A wins";
            bar.value = 100;
            isOver = true;
            teamAPer_text.text = "100%";
            teamBPer_text.text = "0%";
        }
        else if (matchPoint <= teamBPoint)
        {
            winner.text = "Team B wins";
            bar.value = 0;
            isOver = true;
            teamAPer_text.text = "0%";
            teamBPer_text.text = "100%";
        }
    }

    float WinningCalulation()
    {
        float totalPoints = intenalAPoint + intenalBPoint;
        float teamAChance = intenalAPoint / totalPoints;

        return teamAChance * 100;
    }
}

