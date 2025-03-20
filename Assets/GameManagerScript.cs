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

    [SerializeField] private GameObject endingStuff;
    [SerializeField] private GameObject[] otherSprits = new GameObject[5];
    private void Start()
    {
        Activecollectable();
        cutscenescript.SetCusceneCamera(cutsceneCameras[cameranum]);
        cutscenescript.SetAnimator(animator[cameranum]);
        endingStuff.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void Activecollectable()
    {
        if (Collectables.transform.childCount == 1)
        {
            endingStuff.SetActive(true);
            foreach(GameObject spirit in otherSprits)
            {
                spirit.SetActive(false);
            }
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
