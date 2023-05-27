using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickInteraction : MonoBehaviour, IInteractable
{
	public string _RotuloInteracao => "Pegar";

	public void Interagir()
	{
		Debug.Log("Pizza foi pega");
	}
}
