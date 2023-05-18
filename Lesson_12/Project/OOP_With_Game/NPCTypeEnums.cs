
using System.ComponentModel;

public enum NPCTypeEnums
{
    [Description("An NPC type representing common townsfolk who go about their daily business, providing tips, quests, or trade opportunities for the player.")]
    Villager = 1,
    [Description("An NPC type representing trained soldiers or guards, who patrol areas and provide protection to the player and other NPCs.")]
    Guard,
    [Description("An NPC type representing traders or shopkeepers, who sell goods to the player or offer services such as repairs or item identification.")]
    Merchant,
    [Description("An NPC type representing characters that offer quests or missions for the player to complete, often providing rewards such as experience or items when completed.")]
    QuestGiver,
    [Description("An NPC type representing financial institutions or banks, where players can store or retrieve money, jewels, or other valuable items.")]
    Bank
}