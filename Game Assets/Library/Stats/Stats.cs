using System.Collections;
using System.Collections.Generic;
using FleqpeUtils.BreakInfinity;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public BigDouble attack = 1, speed = 1, health = 1, defense = 1;
    public Stats()
    {
    }
}
public static class StatsExtension
{
    public static Stats MultiplyWith(this Stats current, Stats target)
    {
        Stats stats = new Stats
        {
            attack = current.attack * target.attack,
            speed = current.speed * target.speed,
            health = current.health * target.health,
            defense = current.defense * target.defense
        };
        return stats;
    }
    public static Stats MultiplyWith(this Stats current, BigDouble value)
    {
        Stats stats = new Stats
        {
            attack = current.attack * value,
            speed = current.speed * value,
            health = current.health * value,
            defense = current.defense * value
        };
        return stats;
    }
    public static Stats DivideWith(this Stats current, BigDouble value)
    {
        Stats stats = new Stats
        {
            attack = current.attack / value,
            speed = current.speed / value,
            health = current.health / value,
            defense = current.defense / value
        };
        return stats;
    }
    public static Stats DivideWith(this Stats current, Stats target)
    {
        Stats stats = new Stats
        {
            attack = current.attack / target.attack,
            speed = current.speed / target.speed,
            health = current.health / target.health,
            defense = current.defense / target.defense
        };
        return stats;
    }
}