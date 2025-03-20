using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public GameObject MainCamera; // main camera
    public GameObject CutsceneCamera; // cut scene camera
    public Animator animator1;

 
    public void CutsceneStart()
    {
        MainCamera.SetActive(false);
        CutsceneCamera.SetActive(true);
        animator1.SetBool("playanim", true);
        Debug.Log("playanim set true");
        Invoke("CutsceneEnd", 4f);
    }

    public void CutsceneEnd()
    {
        MainCamera.SetActive(true);
        CutsceneCamera.SetActive(false);
    }
    public void SetCusceneCamera(GameObject camera)
    {
        CutsceneCamera = camera;
    }
    public void SetAnimator(Animator animator)
    {
        animator1 = animator;
    }
}
