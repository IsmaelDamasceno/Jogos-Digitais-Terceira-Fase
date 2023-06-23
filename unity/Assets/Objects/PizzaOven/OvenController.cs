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
    public void PorPizza(bool valor, GameObject pizza = null)
    {
        if (valor == false)
        {
			ItemController.Pegaritem(_pizza.GetComponent<IItem>());
            _pizza = null;
            _temPizza = false;
		}
        else
        {
			ItemController.Pegaritem(null);
            _temPizza = true;
            _pizza = pizza;

			_pizza.transform.SetParent(_posicaoPizza);
			_pizza.transform.localPosition = Vector3.zero;
			_pizza.transform.localRotation = Quaternion.Euler(Vector3.zero);

			_pizza.GetComponent<Animator>().enabled = false;
			_pizza.GetComponent<Rigidbody>().isKinematic = true;
			_pizza.GetComponent<MeshCollider>().enabled = false;
		}
    }

}
