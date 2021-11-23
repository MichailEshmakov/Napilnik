using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Weapon
    {
        private readonly int  _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(Player player)
        {
            if (CanFire() == false)
                throw new InvalidOperationException();

            player.Damage(_damage);
            _bullets--;
        }

        public bool CanFire()
        {
            return _bullets > 0;
        }
    }

    class Player
    {
        private int _health;

        public bool IsAlive => _health > 0;

        public void Damage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_health > damage)
                _health -= damage;
            else
                _health = 0;
        }
    }

    class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (player.IsAlive && _weapon.CanFire())
            {
                _weapon.Fire(player);
            }
        }
    }
}
