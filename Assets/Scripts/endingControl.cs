using UnityEngine;
using System.Collections;

public class endingControl : MonoBehaviour
{
    private AudioSource m_AudioSource;
    private bool m_IsPlaying = false;
    [SerializeField] private GameObject[] forestSpirits = new GameObject[5];

    private float m_Time = 0f;
    [SerializeField] private float AudioTime = 17;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlaying)
        {
            if (m_Time > 0)
            {
                m_Time -= Time.deltaTime;
            }
            else
            {
                foreach(GameObject spirit in forestSpirits)
                {
                    spirit.GetComponent<fadeOut>().StartFadeOut();
                }
                m_IsPlaying = false;
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().playerCanMove = true;
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enableHeadBob = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FirstPersonController>().playerCanMove = false;
            other.gameObject.GetComponent<FirstPersonController>().enableHeadBob = false;
            m_IsPlaying = true;
            m_Time = AudioTime;
        }

    }
}
