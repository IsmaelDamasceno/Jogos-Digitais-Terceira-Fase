using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public string Nome { get; }
    public void Entrar();
    public void Tick();
    public void Sair();
}
