using TestProject.Core.Entity.Player;
using TestProject.Core.Entity.Player.Movement;
using TestProject.Core.Entity.Player.Zone;
using UnityEngine;
using Zenject;

namespace TestProject.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMoveZone playerMoveZone;
        [SerializeField] private PlayerUnit playerUnit;

        public override void InstallBindings()
        {
            Container.Bind<PlayerUnit>().FromInstance(playerUnit);
            Container.Bind<PlayerMoveZone>().FromInstance(playerMoveZone);

            Container.Bind<PlayerMover>().FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}