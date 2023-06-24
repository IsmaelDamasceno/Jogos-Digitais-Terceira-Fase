using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController: MonoBehaviour
{
	private static GameObject s_dialogBox;
	private static TextMeshProUGUI s_dialogText;

	private void Start()
	{
		if (s_dialogBox != null)
		{
			Destroy(this);
			return;
		}

		s_dialogBox = GameObject.FindGameObjectWithTag("Dialog");
		s_dialogText = s_dialogBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		s_dialogBox.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (s_dialogBox.activeInHierarchy)
			{
				MostrarMsg("");
			}
		}
	}

	public static void MostrarMsg(string mensagem)
	{

		if (mensagem == "")
		{
			s_dialogBox.SetActive(false);
			Time.timeScale = 1f;
		}
		else
		{
			s_dialogBox.SetActive(true);
			s_dialogText.text = mensagem;
			Time.timeScale = 0f;
		}
	}
}
