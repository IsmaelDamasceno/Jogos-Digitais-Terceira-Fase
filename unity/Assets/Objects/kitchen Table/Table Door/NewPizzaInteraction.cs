using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPizzaInteraction : MonoBehaviour, IInteractable
{
    public string _RotuloInteracao => "Pegar nova pizza";
    private GameObject _pizzaPrefab;

    public void Interagir()
    {
        GameObject newPizza = Instantiate(_pizzaPrefab);
        GrabItem.TocarSom();
        ItemController.Pegaritem(newPizza.GetComponent<IItem>());
	}

    void Start()
    {
        _pizzaPrefab = Resources.Load<GameObject>("Pizza");
	}

    void Update()
    {
        
    }
}
