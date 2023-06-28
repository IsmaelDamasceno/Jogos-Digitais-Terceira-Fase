using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickInteraction : MonoBehaviour, IInteractable
{
    public string _RotuloInteracao => "Pegar Pizza";

    public void Interagir()
    {
        GrabItem.TocarSom();
        ItemController.Pegaritem(GetComponent<IItem>());
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
