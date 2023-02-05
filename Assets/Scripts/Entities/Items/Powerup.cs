using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Item
{
    public override void GrantEffect(Player player)
    {
        player.GainShield();
    }
}
