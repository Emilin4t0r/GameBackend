static class Extension
{
    public static Item GetHighestLevelItem(this Player player)
    {
        Item highestLevelItem = null;
        for (int i = 0; i < player.Items.Count; i++)
        {
            if (highestLevelItem == null) highestLevelItem = player.Items[i];
            for (int j = 0; j < player.Items.Count; j++)
            {
                if (i != j)
                {
                    if (player.Items[j].Level > highestLevelItem.Level)
                    {
                        highestLevelItem = player.Items[j];
                    }
                }
            }
        }
        return highestLevelItem;
    }
}