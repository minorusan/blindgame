using Core;
using UnityEngine;

public class MoveCommand : ICommand
{
    private EMoveDirection _direction;

    public MoveCommand(EMoveDirection direction)
    {
        _direction = direction;
    }

    public void Execute()
    {
        ServiceProvider.GetService<PlayerMovement>().Move(_direction);
    }
}
