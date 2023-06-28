using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarPickInteraction : MonoBehaviour, IInteractable
{
    public string _RotuloInteracao => "Pegar Molho de Tomate";

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
