using UnityEngine;

public class collectioncontroller : MonoBehaviour
{

    [SerializeField]
    private int collectables = 0;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collectables++;
            Destroy(collision.gameObject);
        }
    }
}
