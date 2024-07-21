using System;
using TestProject.Core.Entity.Player.Zone;
using TestProject.InputSystem;
using UnityEngine;

namespace TestProject.Core.Entity.Player.Movement
{
    public class PlayerMover : IDisposable
    {
        private const int SPEED = 4;

        private PlayerUnit unit;
        private PlayerMoveZone moveZone;
        private IPlayerInputHandler inputHandler;

        public PlayerMover(PlayerUnit playerUnit, PlayerMoveZone playerMoveZone, IPlayerInputHandler playerInputHandler)
        {
            unit = playerUnit;
            moveZone = playerMoveZone;
            inputHandler = playerInputHandler;

            Subscribe();
        }

        private void Subscribe()
        {
            inputHandler.MoveUp += OnMoveUp;
            inputHandler.MoveDown += OnMoveDown;
            inputHandler.MoveLeft += OnMoveLeft;
            inputHandler.MoveRight += OnMoveRight;
        }

        private void Unsubscribe()
        {
            inputHandler.MoveUp -= OnMoveUp;
            inputHandler.MoveDown -= OnMoveDown;
            inputHandler.MoveLeft -= OnMoveLeft;
            inputHandler.MoveRight -= OnMoveRight;
        }

        private void OnMoveUp()
        {
            unit.PlayerTransform.position = GetNewPosition(Vector3.up);
        }

        private void OnMoveDown()
        {
            unit.PlayerTransform.position = GetNewPosition(Vector3.down);
        }

        private void OnMoveLeft()
        {
            unit.PlayerTransform.position = GetNewPosition(Vector3.left);
        }

        private void OnMoveRight()
        {
            unit.PlayerTransform.position = GetNewPosition(Vector3.right);
        }

        private Vector3 GetNewPosition(Vector3 direction)
        {
            var newPosition = SPEED * Time.deltaTime * direction + unit.PlayerTransform.position;

            return moveZone.CorrectPositionByZone(newPosition);
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}