using System;
public class Item
{
    public Guid Id { get; set; }
    public int Level { get; set; }
    public Item(Guid id, int level)
    {
        Id = id;
        Level = level;
    }
}