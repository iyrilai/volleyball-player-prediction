using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Data Data { get; set; }

    [SerializeField] UI UI;
    [SerializeField] TMP_Text error;

    [SerializeField] TMP_InputField playerName;
    [SerializeField] TMP_InputField playerID;
    [SerializeField] TMP_InputField matchs;
    [SerializeField] TMP_InputField sp;
    [SerializeField] TMP_InputField ap;
    [SerializeField] TMP_InputField dp;

    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Data = new Data();
        Data.Init();
    }

    public void Submit()
    {
        var name = playerName.text;

        int id = int.Parse(playerID.text);
        int matchs = int.Parse(this.matchs.text);
        int sp = int.Parse(this.sp.text);
        int ap = int.Parse(this.ap.text);
        int dp = int.Parse(this.dp.text);

        if (Data.IsPlayerThere(id))
        {
            error.text = "Player ID already exist";
            return;
        }

        Data.CreatePlayer(id, name, matchs, sp, dp, ap);
        UI.LoadScene(UI.Scene.MainMenu);

        playerName.text = string.Empty;
        playerID.text = string.Empty;
        this.matchs.text = string.Empty;
        this.sp.text = string.Empty;
        this.dp.text = string.Empty;
        this.ap.text = string.Empty;
    }
}