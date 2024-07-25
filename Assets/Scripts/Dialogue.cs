using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public TMP_Text text;
    public TMP_Text continueText;
    public string[] lines;
    public float textSpeed;
    public float startDelay;
    int index;

    void Start()
    {
        text.text = string.Empty;
        StartCoroutine(StartDialogue());
    }

    void Update()
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

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(startDelay);
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
    }
}
