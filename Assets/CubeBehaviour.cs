using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    //Variable de tipo cubeBehaviour a la que acceder desde otras clases en caso de ser necesario
    public static CubeBehaviour cubeInstance { get; private set; }
    public static Transform VectorToLook;
    private void OnTriggerStay(Collider other)
    {
        //transform.LookAt
    }

    //Para mantener la instancia del cubo intacta nos aseguramos preguntando si es nula y diferente a este script
    //Este metodo de instanciar clases es el conocido como Singleton
    public void Awake()
    {
        if (cubeInstance!=null && cubeInstance != this)
        {
            Destroy(this);

        }
        else
        {
            cubeInstance = this;
        }
    }//Aqui hago un singleton para poder impelentarlo en futuros niveles y queremos acceder a una funcionalidad o variable del cubo

}
public class CubeController : Command
{
    public override void Execute(/*Transform _boxTrans, Command command*/)
    {
        //_boxTrans.Translate(_boxTrans +)
    }
}
public class InputHandler: MonoBehaviour
{
    private CubeController ButtonW, ButtonD, ButtonA, ButtonZ;

    public static List<CubeController> OldActions = new List<CubeController>();

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ButtonW.Execute();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ButtonD.Execute();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ButtonA.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ButtonZ.Execute();
        }
    }

}
