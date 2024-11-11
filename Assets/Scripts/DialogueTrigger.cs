using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public TMP_Text text;
    public TMP_Text continueText;
    public string[] lines;
    public float textSpeed;
    int index;
    public bool playingText = false;
    public Dictionary<string, string[]> textMap = new Dictionary<string, string[]>();


    void Start()
    {

        textMap.Add("gun", new string[] { "Good, now find the ammo" });
        textMap.Add("ammo", new string[] { "Good, now find the gun" });
        textMap.Add("monster", new string[] { "Kill the monster..." });
        textMap.Add("win", new string[] { "The monster is dead and you are safe...", "For now..." });
        textMap.Add("door", new string[] { "Who's at the door?" });

        text.text = string.Empty;
    }

    void Update()
    {
        if (playingText)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (text.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    continueText.gameObject.SetActive(true);
                    text.text = lines[index];
                }
            }
        }

    }

    public void StartDialogue(string key)
    {
        playingText = true;
        lines = textMap[key];
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            GetComponent<AudioSource>().pitch = Random.Range(0.4f, 1.7f);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(textSpeed);
        }
        continueText.gameObject.SetActive(true);
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            continueText.gameObject.SetActive(false);
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            continueText.gameObject.SetActive(false);
            // gameObject.SetActive(false);
            playingText = false;
            text.text = string.Empty;
        }
    }
}
