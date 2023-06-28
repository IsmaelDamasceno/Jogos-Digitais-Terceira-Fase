using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDataController : MonoBehaviour
{
	public float _TempoSegundos;
	private TextMeshProUGUI _timer;

	void Start()
	{
		_timer = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
		StartCoroutine(AtualizaTimer());
	}

	void Update()
	{

	}

	private IEnumerator AtualizaTimer()
	{
		while (true)
		{
			int minutos = (int)Mathf.Floor(_TempoSegundos / 60f);

			int segundos = (int)(_TempoSegundos % 60f);
			string segundosStr = segundos < 10? $"0{segundos}": segundos.ToString();

			string tempoStr = $"{minutos}:{segundosStr}";
			_timer.text = tempoStr;

			_TempoSegundos--;

			yield return new WaitForSeconds(1f);
		}
	}
}
