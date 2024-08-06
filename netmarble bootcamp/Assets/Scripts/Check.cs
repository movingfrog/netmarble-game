using UnityEngine;

public class Check : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Enemy.IsPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy.IsPlayer = false;
    }
}
