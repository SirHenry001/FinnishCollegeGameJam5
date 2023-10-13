using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Windows;


public class DialogueSystem : MonoBehaviour
{
    public GameObject audioPlayerObject;
    private AudioSource audioSource;
    private bool wizardLotionDone = false;
    private bool buttonHasBeenPressed = false;
    private bool boxHasBeenOpened = false;

    public bool  canDialog = false;
    public float nextDialogTime = 0f;
    public float nextDialogTimer = 0f; //private
    public float nextDialogLineTime = 0f; //private
    public float nextDialogLineTimer= 0f; //private
    public float[] nextDialogLineTimes;
    public bool pausingForNextLine = false; //private
    private int nextDialogNumber = 0;

    private bool dialogueIsShowing = false;

    public int dialogCaseNum = 0;

        public int dialogueCasePartNum = 0;
        private GameObject activeSpeakerPortraitObject; //private
        public GameObject fishPortrait;
        public GameObject broccoliPortrait;
        public GameObject bossPortrait;
        public GameObject dialogueBackground;
    public GameObject dialogueTextObject;
        public int[] speakerPortraits;
        public AudioClip dialogueAudioFile;
        public AudioClip[] dialogueAudioFiles; 
        public string dialogueString = "You shouldn't see this line.";
        public string[] dialogueStrings;
        public float dialogueShowTime = 0f;
    public float[] dialogueShowTimes;
        public float displayTimer = 0f; //private
    
        public float dialogueDelayBeforeNextLine = 0f;

    private void Awake()
    {
        GameManager.ChanceToMelt += startSunDamageTutorial;
        GameManager.Success += startEndingDialogue;
        GameManager.Fail += startDeathDialogue;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioPlayerObject.GetComponent<AudioSource>();
        startNewDialogue(0);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            playWizardLotion();
        }*/

        if (dialogueIsShowing == false) { nextDialogTimer += Time.deltaTime; }
        if (nextDialogTimer >= 20f) {
            randomizeNextDialogue();
            nextDialogTimer = 0f;
            pausingForNextLine = false;
            nextDialogLineTimer = 0f;
            startNewDialogue(nextDialogNumber);
            //dialogueIsShowing = true;
           // displayTimer = 0;
          //  initializeDialogueLine(speakerPortraits[nextDialogNumber], dialogueAudioFiles[nextDialogNumber], dialogueStrings[nextDialogNumber], dialogueShowTimes[nextDialogNumber], nextDialogLineTimes[nextDialogNumber]);
           // dialogueBackground.SetActive(true);

        }

        if (dialogueIsShowing == true) { displayTimer += Time.deltaTime; }
        if (dialogueIsShowing == true && displayTimer >= dialogueShowTime)
        {
            dialogueIsShowing = false;
            dialogueBackground.SetActive(false);
            if (nextDialogLineTime >= 0.5f) { pausingForNextLine = true; }
            else { nextDialogTimer = 0f; dialogueCasePartNum = 0; }
            displayTimer = 0f;
        }
        if (pausingForNextLine == true)
            {
            nextDialogLineTimer += Time.deltaTime;
            }
        if (pausingForNextLine == true && nextDialogLineTimer >= nextDialogLineTime)
        {
            dialogueCasePartNum++;
            nextDialogTimer = 0f;
            pausingForNextLine = false;
            nextDialogLineTimer = 0f;
            dialogueIsShowing = true;
            displayTimer = 0;
            initializeDialogueLine(speakerPortraits[dialogCaseNum + dialogueCasePartNum], dialogueAudioFiles[dialogCaseNum + dialogueCasePartNum], dialogueStrings[dialogCaseNum + dialogueCasePartNum], dialogueShowTimes[dialogCaseNum + dialogueCasePartNum], nextDialogLineTimes[dialogCaseNum +dialogueCasePartNum]);
            dialogueBackground.SetActive(true);
        }
    }


    public void startNewDialogue(int dialogCaseNumber)
    {
        //initializeDialogueLine
        displayTimer = 0;
        dialogueCasePartNum = 0;
        dialogueIsShowing = true;
        dialogCaseNum = dialogCaseNumber;
        pausingForNextLine = false;
        initializeDialogueLine(speakerPortraits[dialogCaseNumber], dialogueAudioFiles[dialogCaseNumber], dialogueStrings[dialogCaseNumber], dialogueShowTimes[dialogCaseNumber], nextDialogLineTimes[dialogCaseNumber]);
        dialogueBackground.SetActive(true);
    }

    public void initializeDialogueLine(int speaker, AudioClip audioFile, string dialogueText, float displayTime, float nextLineTime)
    {
        switch (speaker)
        {
            case 0:
                activeSpeakerPortraitObject = fishPortrait;
                break;
            case 1:
                activeSpeakerPortraitObject = broccoliPortrait;
                break;
            case 2:
                activeSpeakerPortraitObject = bossPortrait;
                break;
        }
        broccoliPortrait.SetActive(false);
        fishPortrait.SetActive(false);
        bossPortrait.SetActive(false);
        activeSpeakerPortraitObject.SetActive(true);
        nextDialogLineTime = nextLineTime;
        dialogueAudioFile = audioFile;
        dialogueString = dialogueText;
        dialogueShowTime = displayTime;
        dialogueTextObject.GetComponent<TextMeshProUGUI>().text = dialogueString;

        audioSource.PlayOneShot(dialogueAudioFile, 1f);

    }

    public void randomizeNextDialogue()
    {
        switch (Random.Range(0,18))
        {
            case 0:
                nextDialogNumber = 13; 
                break;
            case 1:
                nextDialogNumber = 14;
                break;
            case 2:
                nextDialogNumber = 15;
                break;
            case 3:
                nextDialogNumber = 16;
                break;
            case 4:
                nextDialogNumber = 20;
                break;
            case 5:
                nextDialogNumber = 21;
                break;
            case 6:
                nextDialogNumber = 22;
                break;
            case 7:
                nextDialogNumber = 24;
                break;
            case 8:
                nextDialogNumber = 26;
                break;
            case 9:
                nextDialogNumber = 27;
                break;
            case 10:
                nextDialogNumber = 29;
                break;
            case 11:
                nextDialogNumber = 32;
                break;
            case 12:
                nextDialogNumber = 34;
                break;
            case 13:
                nextDialogNumber = 35;
                break;
            case 14:
                nextDialogNumber = 37;
                break;
            case 15:
                nextDialogNumber = 38;
                break;
            case 16:
                nextDialogNumber = 39;
                break;

            default:
                nextDialogNumber = 21;
                break;

        }
    }
    public void startDeathDialogue()
    {
        startNewDialogue(41);
    }

    public void playWizardLotion()
    {
        if (wizardLotionDone == false)
        {
            startNewDialogue(40);
            wizardLotionDone = true;
        }
    }

    public void startEndingDialogue()
    {
        startNewDialogue(5);
    }

    /*
    public void startSunDamageTutorial()
    {
        if (buttonHasBeenPressed == false)
        {
            if (boxHasBeenOpened == false)
            {
                startNewDialogue(10);
                boxHasBeenOpened = true;
            }
            else
            {
                startNewDialogue(12);
            }
        }
    }
    */

    public void startSunDamageTutorial()
    {
        if (buttonHasBeenPressed == false)
        {
            Debug.Log("AUKI EKAN KERRAN");
            if (boxHasBeenOpened == false)
            {
                buttonHasBeenPressed = true;
                startNewDialogue(10);
                boxHasBeenOpened = true;
            }

        }
        else if(buttonHasBeenPressed == true)
        {
            Debug.Log("KERRAN JO AUKAISTU");
            startNewDialogue(12);
        }
    }
}
