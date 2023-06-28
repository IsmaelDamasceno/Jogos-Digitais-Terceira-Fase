using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenTakePizzaInteraction : MonoBehaviour, IInteractable
{
    public string _RotuloInteracao => "Pegar Pizza assada";
    public OvenController _OvenController = null;

    public void Ativar(OvenController ovController)
    {
        _OvenController = ovController;
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}
    public void Desativar()
    {
        _OvenController = null;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void Interagir()
    {
        if (_OvenController.TirarPizza())
        {
			Desativar();
		}
	}

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
