using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    protected float moveDistance = 1f;
    public abstract void Execute(Transform objectToMove, Command commandDone);

    public virtual void Undo(Transform objectToMove) { }
    public virtual void Move(Transform objectToMove) { }

}

public class MoveForward : Command
{
    //Funcion espec�fica dentro de este comando que se produce al ejecutar el mismo
    public override void Execute(Transform boxTransform, Command command)
    {
        Move(boxTransform);
        CubeBehaviour.OldActions.Add(command);
    }

    //Funcion espec�fica dentro de este comando que deshace la funci�n de ejecutar del mismo
    public override void Undo(Transform objectToMove)
    {
        objectToMove.Translate(-objectToMove.forward * moveDistance);
    }

    //Funcion espec�fica de este comando que dice como ha de moverse el objeto al que queremos aplicar este patr�n
    public override void Move(Transform objectToMove)
    {
        objectToMove.Translate(objectToMove.forward * moveDistance);
    }
}

public class MoveLeft : Command
{
    //Funcion espec�fica dentro de este comando que se produce al ejecutar el mismo
    public override void Execute(Transform boxTransform, Command command)
    {
        Move(boxTransform);
        CubeBehaviour.OldActions.Add(command);
    }

    //Funcion espec�fica dentro de este comando que deshace la funci�n de ejecutar del mismo
    public override void Undo(Transform objectToMove)
    {
        objectToMove.Translate(objectToMove.right * moveDistance);
    }

    //Funcion espec�fica de este comando que dice como ha de moverse el objeto al que queremos aplicar este patr�n
    public override void Move(Transform objectToMove)
    {
        objectToMove.Translate(-objectToMove.right * moveDistance);
    }
}

public class MoveRight : Command
{
    //Funcion espec�fica dentro de este comando que se produce al ejecutar el mismo
    public override void Execute(Transform boxTransform, Command command)
    {
        Move(boxTransform);
        CubeBehaviour.OldActions.Add(command);
    }

    //Funcion espec�fica dentro de este comando que deshace la funci�n de ejecutar del mismo
    public override void Undo(Transform objectToMove)
    {
        objectToMove.Translate(-objectToMove.right * moveDistance);
    }

    //Funcion espec�fica de este comando que dice como ha de moverse el objeto al que queremos aplicar este patr�n
    public override void Move(Transform objectToMove)
    {
        objectToMove.Translate(objectToMove.right * moveDistance);
    }
}

public class UndoCommand : Command
{
    public override void Execute(Transform objectToMove, Command commandDone)
    {
        List<Command> oldCommands = CubeBehaviour.OldActions;
        if (oldCommands.Count > 0)
        {
            Command lastCommand = oldCommands[oldCommands.Count - 1];
            lastCommand.Undo(objectToMove);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }
}


