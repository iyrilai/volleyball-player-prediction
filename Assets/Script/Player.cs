public class Player
{
    public string Name { get; }
    public int ID { get; }
    public int Matchs { get; }
    public int Sp { get; }
    public int Dp { get; }
    public int Ap { get; }

    public Player(string name, int id, int matchs, int sp, int dp, int ap)
    {
        Name = name;
        ID = id;
        Matchs = matchs;
        Sp = sp;
        Dp = dp;
        Ap = ap;
    }

    public float GetPoint()
    {
        const float points = 25;
        float totalMatchPoint = points * Matchs;
        float totalPoint = Ap + Dp + Sp;

        float playerPoint = totalMatchPoint / totalPoint;

        return playerPoint;
    }
}
