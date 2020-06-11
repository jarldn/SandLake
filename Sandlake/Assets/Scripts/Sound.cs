
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]//Esto nos permite que la clase salga en el inspector
public class Sound{

    public string name; //nombre del clip

    public AudioClip clip;


    [Range(0f,1f)]//Esto hace que en el inspector el rango de valores sea el indicado
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 0.5f)]
    public float randomPitch;
    [HideInInspector]
    public AudioSource source;

    public bool loop;




}
