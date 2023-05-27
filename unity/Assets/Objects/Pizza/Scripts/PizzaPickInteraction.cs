using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickInteraction : MonoBehaviour, IInteractable
{
	public string _RotuloInteracao => "Pegar Pizza";

	public void Interagir()
	{
		ItemController.Pegaritem(GetComponent<IItem>());
	}
}
