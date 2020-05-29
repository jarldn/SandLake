using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;

    }

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;// emparejamos el frame rate con la tasa de refresco de la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
