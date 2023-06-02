using UnityEngine;
public class barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            Destroy(other.gameObject);
        }
    }
}