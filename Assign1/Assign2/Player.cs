using System;
using System.Collections.Generic;
public class Player : IPlayer
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }
    public Player(Guid id, int score, List<Item> items)
    {
        Id = id;
        Score = score;
        Items = items;
    }
}