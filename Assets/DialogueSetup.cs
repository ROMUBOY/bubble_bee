using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogueSetup : MonoBehaviour
{
    [SerializeField] List<string> dialogue = new List<string>();
    [SerializeField] List<GameObject> npc = new List<GameObject>();
    [SerializeField] float delay = 3.0f;
    [SerializeField] TMP_Text display;
    [SerializeField] GameObject displayPanel;
    private IEnumerator coroutine;
    private int index = 0;

    void Start()
    {
        coroutine = ShowDialogue(delay);
        StartCoroutine(coroutine);
    }

    private IEnumerator ShowDialogue(float waitTime)
    {
        index = 0;
        npc[index].SetActive(true);
        for (var index = 0; index < dialogue.Count; index++){

            display.text = "";

            ResetPortraits();
            npc[index].SetActive(true);

            for (var char_index = 0; display.text.Length < dialogue[index].Length; char_index ++){
                display.text += dialogue[index][char_index];
                yield return new WaitForSeconds(0.02f);
            }

            yield return new WaitForSeconds(waitTime);

            if (index + 1 == dialogue.Count){
                Destroy(gameObject);
                yield return null;
            }
        }
    }

    private void ResetPortraits(){
        foreach (GameObject portrait in npc){
            portrait.SetActive(false);
        }
    }
}
