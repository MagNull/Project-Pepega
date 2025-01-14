﻿using System;
using Sources.Runtime.Boss_Components;
using Sources.Runtime.Interfaces;
using Sources.Runtime.Player_Components;
using UnityEngine;

namespace Sources.Runtime
{
    public class ProjectileFactory : MonoBehaviour, IFactory<Projectile>
    {
        [SerializeField]
        private SimpleProjectile _playerSimpleProjectile;
        [SerializeField]
        private SimpleProjectile _enemySimpleProjectile;
        [SerializeField]
        private GolemArm _golemArmPrefab;
        [SerializeField]
        private ReaperSummon _reaperSummon;

        private readonly Type _bossType = typeof(Boss);
        private readonly Type _playerType = typeof(Player);
        private readonly Type _simpleProjectileType = typeof(Projectile);
        private readonly Type _golemsArmType = typeof(GolemArm);
        private readonly Type _reaperSummonType = typeof(ReaperSummon);

        public TProjectile Create<TProjectile, TProductOwner>() where TProjectile : Projectile
        {
            var projectileT = typeof(TProjectile);
            var ownerT = typeof(TProductOwner);

            TProjectile result = null;
            if (projectileT == _simpleProjectileType)
            {
                if (ownerT == _bossType)
                    result = Instantiate(_enemySimpleProjectile, transform) as TProjectile;
                if (ownerT == _playerType)
                    result = Instantiate(_playerSimpleProjectile, transform) as TProjectile;
            }
            else if (projectileT == _golemsArmType)
                result = Instantiate(_golemArmPrefab, transform) as TProjectile;
            else if (projectileT == _reaperSummonType)
                result = Instantiate(_reaperSummon, transform) as TProjectile;
            else
                throw new Exception("Unknown projectile or owner type");

            result.Init(new ProjectileAnimator(result.GetComponent<Animator>()));
            return result;
        }

        public void DestroyAllProjectiles()
        {
            var projectiles = GetComponentsInChildren<Projectile>();
            foreach (var projectile in projectiles)
            {
                projectile.Disable();
            }
        }
    }
}