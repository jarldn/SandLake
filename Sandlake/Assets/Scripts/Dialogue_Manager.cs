using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue_Manager : MonoBehaviour
{
    public int contadorConversacion;

    public bool finishDialog;

    public Dialogue dialogue;

    Queue<string> sentences;

    public GameObject dialoguePanel;

    public TextMeshProUGUI displayText;

    string activeSentence;

    public float typingSpeed;

    AudioSource myAudio;

    public AudioClip speakSound;

    public Image image;
    public Sprite face;
    private bool isPlayerClose;



    void Start()
    {
        finishDialog = false;
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
        image.enabled = false;
        contadorConversacion = 0;

    }

    void Update()
    {

        Debug.Log("Dialog_" + contadorConversacion);
        Debug.Log("sentence_" + sentences.Count);
        //if (Input.GetButtonDown("Interactuar") && isPlayerClose && finishDialog == false)
        //{
        //    image.enabled = true;
        //}


    }





    void StartDialogue()
    {

        sentences.Clear();

        foreach (string sentence in dialogue.sentenceList)

        {
            sentences.Enqueue(sentence);

        }

        image.enabled = true;

        image.enabled = true;
        image.sprite = face;

        DisplayNextSentence();

    }

    void DisplayNextSentence()
    {

        if (sentences.Count <= 0)
        {

            finishDialog = true;
            displayText.text = activeSentence;

            return;
        }

        contadorConversacion =  0;
        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;



        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));

    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {



            isPlayerClose = true;
        }


    }




    private void OnTriggerStay2D(Collider2D col)
    {



        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interactuar") && dialoguePanel.activeSelf == false)
            {


                dialoguePanel.SetActive(true);
                StartDialogue();
            }
            else if (Input.GetButtonDown("Interactuar") && displayText.text == activeSentence)
            {

                DisplayNextSentence();


            }


            if (Input.GetButtonDown("Interactuar") && finishDialog == true)
            {

                contadorConversacion++;
                Debug.Log(finishDialog);
                dialoguePanel.SetActive(false);
                StopAllCoroutines();

                EndDialogue();

            }

        }


    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
            isPlayerClose = false;
            EndDialogue();

        }




    }







    void EndDialogue()
    {
        image.enabled = false;
        Debug.Log("end2");
        finishDialog = false;
    }



}
