using System;

class Clip
{
    public int BulletsCount { get; private set; }

    private int _bulletsMinCount = 0;

    public Clip(int bulletsCount)
    {
        BulletsCount = bulletsCount;
    }

    public bool TryToFire(int decreasingCount = 1)
    {
        if (BulletsCount - decreasingCount < _bulletsMinCount)
        {
            return false;
        }

        BulletsCount -= decreasingCount;
        return true;
    }
}

class Weapon
{
    public int Damage { get; private set; }

    private Clip _clip;

    public Weapon(int damage, Clip clip)
    {
        Damage = damage;
        _clip = clip;
    }

    public void Fire(Player player)
    {
        if (_clip.TryToFire())
        {
            player.Health.TakeDamage(Damage);
        }
    }
}

class Player
{
    public Health Health { get; private set; }
}

class Health
{
    private int _value;
    private int _maxValue;

    public void TakeDamage(int damage)
    {
        _value = Math.Clamp(_value - damage, 0, _maxValue);
    }
}

class Bot
{
    public Weapon Weapon;

    public void OnSeePlayer(Player player)
    {
        Weapon.Fire(player);
    }
}