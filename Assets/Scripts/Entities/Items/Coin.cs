using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void GrantEffect(Player player)
    {
        player.AddCoin();
    }
}
