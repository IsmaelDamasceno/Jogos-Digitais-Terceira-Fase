using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{

    private GameObject _keyInfo;
    private GameObject _label;

    void Start()
    {
        _keyInfo = transform.GetChild(0).gameObject;
        _label = transform.GetChild(1).gameObject;

        _keyInfo.SetActive(false);
        _label.SetActive(false);
    }

    public void SetarInteracao(string rotulo, bool ativo)
    {

		_keyInfo.SetActive(ativo);
		_label.SetActive(ativo);

		if (ativo)
        {
            _label.GetComponent<TextMeshProUGUI>().text = rotulo;
        }
    }
}
