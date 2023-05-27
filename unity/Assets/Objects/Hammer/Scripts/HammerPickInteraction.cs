using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickInteraction : MonoBehaviour, IInteractable
{
	public string _RotuloInteracao => "Pegar Martelo";
	public void Interagir()
	{
		ItemController.Pegaritem(GetComponent<IItem>());
	}
}
