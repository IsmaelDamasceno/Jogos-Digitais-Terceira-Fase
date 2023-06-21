using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzarelaPickInteraction : MonoBehaviour, IInteractable
{
    public string _RotuloInteracao => "Pegar Mussarela";

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
