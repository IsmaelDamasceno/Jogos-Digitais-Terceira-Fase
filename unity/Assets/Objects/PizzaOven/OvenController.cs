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

			if (_ligado)
			{
				DialogController.MostrarMsg("Forno já está ligado!");
				return false;
			}
			if (_aberto)
			{
				DialogController.MostrarMsg("Forno deve estar fechado para ligar!");
				return false;
			}
			if (!_temPizza)
			{
				DialogController.MostrarMsg("Forno deve ter pizza para ligar!");
				return false;
			}

			_ligado = true;
			return true;
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
			if (_aberto)
			{
				DialogController.MostrarMsg("Forno já está aberto!");
				return false;
			}
			if (_ligado)
			{
				DialogController.MostrarMsg("Forno deve estar desligado para abrir!");
				return false;
			}

			_aberto = true;
			return true;
		}
		else
		{
			_aberto = false;
			return true;
		}
    }

	public bool TirarPizza()
	{
		if (_temPizza == false)
		{
			DialogController.MostrarMsg("Forno está vazio!");
			return false;
		}

		ItemController.Pegaritem(_pizza.GetComponent<IItem>());
		_pizza = null;
		_temPizza = false;
		return true;
	}
	public bool ColocarPizza(GameObject pizza)
	{
		#region Verificações
		if (pizza == null)
		{
			throw new UnityException("O parâmetro piza não pode ser null");
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

		if (pizza.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
		{
			DialogController.MostrarMsg("Amasse a pizza antes de assar!");
			return false;
		}

		if (PizzaTextureSet.PizzaProntaAssar(pizza) == false)
		{
			DialogController.MostrarMsg("Coloque os ingredientes antes de assar!");
			return false;
		}

		if (PizzaTextureSet.PizzaAssada(pizza))
		{
			DialogController.MostrarMsg("Pizza já está assada!");
			return false;
		}
		#endregion

		#region Lógica
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
