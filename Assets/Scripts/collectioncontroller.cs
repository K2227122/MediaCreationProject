using UnityEngine;

public class collectioncontroller : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Destroying child");
            gameManagerScript.NextChild();
        }
    }

    
}
