using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; //Esto es el array de sonidos


    public static AudioManager instance;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Start Game")
        {
            Destroy(gameObject);
        }

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        //estas primeras líneas sirven para que el audio manager permanezca a través de escenas^^



        foreach (Sound s in sounds)//recorremos el array y asignamos un AudioSource a cada game object y le damos un clip, un volumen y un pitch
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;


        }
    }

    // Update is called once per frame
    public void Play(string name)//método para que suene un sonido
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);// Buscamos en el array el sonido que tiene el mismo nombre que name
        if (s == null)//esto es para que si no encuentra el sonido (por ejemplo si hay un error en el nombre) salga de la función antes de intentar tocarlo y así no de error
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }
        if (!s.source.isPlaying)
        {
            s.source.pitch = s.pitch * (1 + UnityEngine.Random.Range(-s.randomPitch / 2f, s.randomPitch / 2f));
            s.source.Play();
        }
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }
        s.source.Pause();
    }
}
