using System;

namespace TestProject.InputSystem
{
    public interface IPlayerInputHandler
    {
        event Action MoveUp;
        event Action MoveDown;
        event Action MoveLeft;
        event Action MoveRight;
    }
}