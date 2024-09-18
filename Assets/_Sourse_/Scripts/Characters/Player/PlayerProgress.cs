using System;
using UnityEngine;

public class PlayerProgress
{
    public int LevelCount { get; private set; }
    public int Points { get; private set; }

    public int Gold { get; private set; }

    public event Action<int> GoldChanged;

    public void AddLevel() => LevelCount++;

    public void AddPoins(int points) => Points += points;

    public void UpdateGold()    =>  GoldChanged?.Invoke(Gold);

    public void AddGold(int gold)
    {
        Gold = Mathf.Clamp(Gold += gold, 0, int.MaxValue);
        GoldChanged?.Invoke(Gold);
    }
}