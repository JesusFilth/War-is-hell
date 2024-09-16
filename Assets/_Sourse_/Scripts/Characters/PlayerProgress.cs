public class PlayerProgress
{
    public int LevelCount { get; private set; }
    public int Points { get; private set; }

    public void AddLevel() => LevelCount++;

    public void AddPoins(int points) => Points += points;
}
