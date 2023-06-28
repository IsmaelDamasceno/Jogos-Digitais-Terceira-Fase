using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public struct Musica
{
    public Musica(string nome)
    {
        this._Nome = nome;
        this._Clip = Resources.Load<AudioClip>($"Musics/{nome}");
    }

    public AudioClip _Clip;
    public string _Nome;
}

public class MusicController : MonoBehaviour
{

    private static AudioSource _musicaSource;
    public static GameObject s_Instancia;
    public static readonly Musica[] s_Musicas =
    {
        new Musica("Menu Music"),
        new Musica("Game Music")
    };
    public static int s_MusicaAtual;

    void Start()
    {
        if (s_Instancia == null)
        {
            s_Instancia = gameObject;
            DontDestroyOnLoad(s_Instancia);
            _musicaSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    public static void TocarMusica(string nome)
    {
        int itr = 0;
        foreach(Musica musica in s_Musicas)
        {
            if (musica._Nome == nome)
            {
                if (_musicaSource.isPlaying)
                {
                    _musicaSource.Stop();
                }
                _musicaSource.clip = musica._Clip;
                _musicaSource.Play();
                s_MusicaAtual = itr;
                return;
            }
            itr++;
        }
        throw new UnityException("Música não encontrada!");
    }

    public static string GetMusica()
    {
        return s_Musicas[s_MusicaAtual]._Nome;
    }
}
