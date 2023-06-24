using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OvenController : MonoBehaviour
{

    private bool _ligado = false;
    private bool _aberto = false;

    private bool _temPizza = false;
    private GameObject _pizza = null;
	private Transform _posicaoPizza;

	void Start()
	{
		_posicaoPizza = transform.GetChild(0);
	}

	void Update()
	{

	}

	public bool Ligar(bool valor)
    {
		if (valor)
		{
			if (!_ligado && !_aberto && _temPizza)
			{
				_ligado = true;
				return true;
			}
		}
		else
		{
			if (_ligado && !_aberto && !_temPizza)
			{
				_ligado = false;
				return true;
			}
		}
		return false;
	}
    public bool Abrir(bool valor)
    {
        if (valor)
		{
			if (!_aberto && !_ligado)
			{
				_aberto = true;
				return true;
			}
		}
		else
		{
			_aberto = false;
			return true;
		}
		return false;
    }

	public bool TirarPizza()
	{
		if (_temPizza == false)
		{
			DialogController.MostrarMsg("Forno est� vazio!");
			return false;
		}

		ItemController.Pegaritem(_pizza.GetComponent<IItem>());
		_pizza = null;
		_temPizza = false;
		return true;
	}
	public bool ColocarPizza(GameObject pizza)
	{
		#region Verifica��es
		if (pizza == null)
		{
			throw new UnityException("O par�metro piza n�o pode ser null");
		}

		if (!_aberto)
		{
			DialogController.MostrarMsg("Forno deve estar aberto!");
			return false;
		}
		if (_ligado)
		{
			DialogController.MostrarMsg("Forno deve estar desligado");
			return false;
		}

		if (PizzaTextureSet.PizzaProntaAssar(pizza) == false)
		{
			DialogController.MostrarMsg("Coloque os ingredientes antes de assar!");
			return false;
		}

		if (PizzaTextureSet.PizzaAssada(pizza))
		{
			DialogController.MostrarMsg("Pizza j� est� assada!");
			return false;
		}
		#endregion

		#region L�gica
		ItemController.Pegaritem(null);
		_temPizza = true;
		_pizza = pizza;

		_pizza.transform.SetParent(_posicaoPizza);
		_pizza.transform.localPosition = Vector3.zero;
		_pizza.transform.localRotation = Quaternion.Euler(Vector3.zero);

		_pizza.GetComponent<Animator>().enabled = false;
		_pizza.GetComponent<Rigidbody>().isKinematic = true;
		_pizza.GetComponent<MeshCollider>().enabled = false;

		return true;
		#endregion
	}
}
