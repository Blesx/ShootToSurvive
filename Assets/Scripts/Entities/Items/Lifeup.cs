using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeup : Item
{
    public override void GrantEffect(Player player)
    {
        player.AddLife(1);
    }
}
