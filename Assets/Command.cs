using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    protected float moveDistance = 1f;
    public abstract void Execute();

    public virtual void Undo() { }
    public virtual void Move() { }

}
