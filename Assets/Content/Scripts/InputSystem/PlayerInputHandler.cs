using System;
using UnityEngine;
using Zenject;

namespace TestProject.InputSystem
{
    public class PlayerInputHandler : IPlayerInputHandler, ITickable
    {
        public event Action MoveUp;
        public event Action MoveDown;
        public event Action MoveLeft;
        public event Action MoveRight;

        public void Tick()
        {
            MoveUpHandler();
            MoveDownHandler();
            MoveLeftHandler();
            MoveRightHandler();
        }

        private void MoveUpHandler()
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveUp?.Invoke();
            }
        }

        private void MoveDownHandler()
        {
            if (Input.GetKey(KeyCode.S))
            {
                MoveDown?.Invoke();
            }
        }

        private void MoveLeftHandler()
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft?.Invoke();
            }
        }

        private void MoveRightHandler()
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight?.Invoke();
            }
        }
    }
}
