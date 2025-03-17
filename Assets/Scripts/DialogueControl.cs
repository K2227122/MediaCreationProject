using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using System.Collections;

public class DialogueControl : MonoBehaviour
{
    // [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text dialoguebox;
    [TextArea(4, 100)] [SerializeField] private string dialogue;

    private AudioSource audioSource;
    private bool audioHasPlayed = false;

    [SerializeField] private float charactersPerSecond = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeTextUncapped(string line)
    {
        float timer = 0;
        float interval = 1 / charactersPerSecond;
        string textBuffer = null;
        char[] chars = line.ToCharArray();
        int i = 0;

        while (i < chars.Length)
        {
            if (timer < Time.deltaTime)
            {
                textBuffer += chars[i];
                dialoguebox.text = textBuffer;
                timer += interval;
                i++;
            }
            else
            {
                timer -= Time.deltaTime;
                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            panel.SetActive(true);


        }
        if (!audioHasPlayed)
        {
            audioSource.Play();
            audioHasPlayed=true;
            StartCoroutine(TypeTextUncapped(dialogue));
        }
        else
        {
            dialoguebox.text = dialogue;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(false);
        }
    }
}
