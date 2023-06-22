using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoniPickInteraction : MonoBehaviour, IInteractable
{
    public string _RotuloInteracao => "Pegar Pepperoni";

    public void Interagir()
    {
        ItemController.Pegaritem(GetComponent<IItem>());
    }

    void Start()
    {

    }

    void Update()
    {

    }
}