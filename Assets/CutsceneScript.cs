using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public Animator animator1;

    public void Start()
    {
    }
    public void CutsceneStart()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        animator1.SetBool("playanim", true);
        Debug.Log("playanim set true");
    }

    public void CutsceneEnd()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }
}
