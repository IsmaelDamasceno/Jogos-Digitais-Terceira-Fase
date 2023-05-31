using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    private static List<IState> _listaEstados;
    private static int _estadoAtualId = -1;

    void Start()
    {
        
    }

    void Update()
    {
        if (_estadoAtualId != -1)
        {
            _listaEstados[_estadoAtualId].Tick();
        }
    }

    public static void AdicionarEstado(IState novoEstado)
    {
        _listaEstados.Add(novoEstado);
    }

    public static IState GetEstado(string estadoNome)
    {
        foreach(IState iEstado in _listaEstados)
        {
            if (iEstado.Nome == estadoNome)
            {
                return iEstado;
            }
        }
        return null;
    }

    public static void SetEstado(string estadoNome)
    {

        int i = 0;
        foreach(IState iEstado in _listaEstados)
        {
            if (iEstado.Nome == estadoNome)
            {
                if (_estadoAtualId != -1)
                {
                    _listaEstados[_estadoAtualId].Sair();
                }
                _estadoAtualId = i;
                _listaEstados[_estadoAtualId]
            }
            i++;
        }
        // throw Exception();
    }
}
