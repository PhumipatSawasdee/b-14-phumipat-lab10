using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    public override void ApplyPowerUp(Player player)
    {
        player.PowerUp(speedMultiplier, duration);
    }
}
