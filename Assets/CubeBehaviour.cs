using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    //Variable de tipo cubeBehaviour a la que acceder desde otras clases en caso de ser necesario
    public static CubeBehaviour cubeInstance { get; private set; }
    public static bool canMove = false;

    private Command ButtonW, ButtonD, ButtonA, ButtonZ;
    private int undoChances = 3;
    public int moveChances = 1;
    public static List<Command> OldActions = new List<Command>();

    public GameObject winCanvas;
    Observable cubeObservable = new Observable();
    //Para mantener la instancia del cubo intacta nos aseguramos preguntando si es nula y diferente a este script
    //Este metodo de instanciar clases es el conocido como Singleton
    public void Awake()
    {
        winCanvas.SetActive(false);
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

        EndCube endCube = new EndCube(winCanvas);
        cubeObservable.AddObserver(endCube);
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
            if (moveChances > 0)
            {
                moveChances--;
                ButtonW.Execute(cubeInstance.transform, ButtonW);
                canMove = false;
                PlayerController.instance.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (moveChances > 0)
            {
                moveChances--;
                ButtonD.Execute(cubeInstance.transform, ButtonD);
                canMove = false;
                PlayerController.instance.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (moveChances > 0)
            {
                moveChances--;
                ButtonA.Execute(cubeInstance.transform, ButtonA);
                canMove = false;
                PlayerController.instance.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (undoChances > 0)
            {
                undoChances--;
                ButtonZ.Execute(cubeInstance.transform, ButtonZ);
                canMove = false;
                PlayerController.instance.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FinalCube")
        {
            if (transform.position == other.transform.position)
            {
                cubeObservable.Notify();
            }
        }
    }

}


