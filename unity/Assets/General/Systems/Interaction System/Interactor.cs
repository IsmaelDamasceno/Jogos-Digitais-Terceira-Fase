using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    [SerializeField] private float _interacaoDistancia;
    [SerializeField] private LayerMask _interacaoMask;

    void Start()
    {
        
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _interacaoDistancia, _interacaoMask))
        {
            IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();
			string rotulo = interactable._RotuloInteracao;
            InteractionTrigger trigger = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InteractionTrigger>();
            trigger.SetarInteracao(rotulo, true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interagir();
			}
        }
        else
        {
			InteractionTrigger trigger = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InteractionTrigger>();
			trigger.SetarInteracao("", false);
		}
    }
}
