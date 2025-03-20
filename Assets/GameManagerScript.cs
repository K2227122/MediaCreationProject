using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    #region collectables
    public GameObject Collectables; // 5 children for the collectables
    public Rigidbody PlayerRigidBody;
    private Rigidbody collectableRigidbody;
    private int childnum = 0;
    #endregion

    #region bush
    public CutsceneScript cutscenescript;
    public GameObject[] cutsceneCameras;
    public Animator[] animator;

    private int cameranum = 0;
    #endregion
    private void Start()
    {
        Activecollectable();
        cutscenescript.SetCusceneCamera(cutsceneCameras[cameranum]);
        cutscenescript.SetAnimator(animator[cameranum]);
    }

    private void Update()
    {
        
    }

    private void Activecollectable()
    {
        if (Collectables.transform.childCount == 1)
        {
            Debug.Log("You did it!!!!!"); // call final animation
        }
        else{Collectables.transform.GetChild(childnum).gameObject.SetActive(true);Debug.Log(Collectables.transform.GetChild(childnum).gameObject);}
        
    }
    public void NextChild()
    {
        childnum = 1;
        Activecollectable();

        //camera/ animation stuff
        
        cutscenescript.SetCusceneCamera(cutsceneCameras[cameranum]);
        cutscenescript.SetAnimator(animator[cameranum]);
        cutscenescript.CutsceneStart();
        cameranum++;
        Debug.Log("Setting Next Child");
        
    }
}
