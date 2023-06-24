using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OvenController : MonoBehaviour
{

	public float _TempoDeAssar;
	public float _TempoAlerta;

    private bool _ligado = false;
    private bool _aberto = false;
	private bool _assando = false;

    private bool _temPizza = false;
    private GameObject _pizza = null;
	private Transform _posicaoPizza;

	private GameObject _cookCanvas;
	private RectTransform _progressBarTrs;

	private GameObject _alertCanvas;
	private Image _alertImage;
	private Coroutine _rotinaAlerta;

	void Start()
	{
		_posicaoPizza = transform.GetChild(0);


		_cookCanvas = transform.GetChild(1).GetChild(0).gameObject;
		_progressBarTrs = _cookCanvas.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();

		_alertCanvas = transform.GetChild(1).GetChild(1).gameObject;
		_alertImage = _alertCanvas.transform.GetChild(0).GetComponent<Image>();
	}

	void Update()
	{

	}
	
	IEnumerator Assar()
	{
		_cookCanvas.SetActive(true);
		float intervalo = _TempoDeAssar / 60f;
		for(float i = 0; i < _TempoDeAssar; i+=intervalo)
		{
			float porcentagem = i / _TempoDeAssar;
			Vector3 novaEscala = new Vector3(porcentagem, 1f, 1f);
			_progressBarTrs.localScale = novaEscala;

			yield return new WaitForSeconds(intervalo);
		}
		_cookCanvas.SetActive(false);
		_assando = false;
		_rotinaAlerta = StartCoroutine(Alerta());
	}
	IEnumerator Alerta()
	{
		_alertCanvas.SetActive(true);

		float intervalo = _TempoAlerta / 60f;
		for (float i = 0; i < _TempoAlerta; i += intervalo)
		{
			float brilho = i / _TempoAlerta;
			Color novaCor = new Color(brilho, brilho, brilho);
			_alertImage.color = novaCor;

			yield return new WaitForSeconds(intervalo);
		}
		_alertCanvas.SetActive(false);
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
			_assando = true;
			StartCoroutine(Assar());
			return true;
		}
		else
		{
			if (_assando)
			{
				DialogController.MostrarMsg("Espere a pizza assar antes de desligar!");
				return false;
			}

			_ligado = false;
			if (_rotinaAlerta != null)
			{
				_alertCanvas.SetActive(false);
				StopCoroutine(_rotinaAlerta);
			}
			return true;
		}
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
