using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer 
{
    public abstract void OnNotify();
}

public abstract class Events
{
    public abstract void onPointMaterial(Material _newMat, GameObject objectToChange);
}

public class OnChangeBoxMat : Events
{
    public override void onPointMaterial(Material _newMat, GameObject objectToChange)
    {
        objectToChange.GetComponent<MeshRenderer>().material = _newMat;
    }
}

public class EndCube : Observer
{
    GameObject winCanvas;
    

    public EndCube(GameObject canvas)
    {
        this.winCanvas = canvas;
        
    }

    public override void OnNotify()
    {
        ActivateCanvas();
    }

    void ActivateCanvas()
    {
        winCanvas.SetActive(true);
    }

}
