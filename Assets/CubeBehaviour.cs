using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    //Variable de tipo cubeBehaviour a la que acceder desde otras clases en caso de ser necesario
    public static CubeBehaviour cubeInstance { get; private set; }
    public static bool canMove = false;

    private Command ButtonW, ButtonD, ButtonA, ButtonZ;

    public static List<Command> OldActions = new List<Command>();
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

    private void Start()
    {
        ButtonW = new MoveForward();
        ButtonA = new MoveLeft();
        ButtonD = new MoveRight();
        ButtonZ = new UndoCommand();
    }

    private void Update()
    {
        Debug.Log(canMove);
        if (canMove)
        {
            HandleInput();
        }
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ButtonW.Execute(cubeInstance.transform, ButtonW);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ButtonD.Execute(cubeInstance.transform, ButtonD);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ButtonA.Execute(cubeInstance.transform, ButtonA);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ButtonZ.Execute(cubeInstance.transform, ButtonZ);
        }
    }

}


