using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Akan mencetak nama objek yang ditabrak oleh pot ini ke Console
        Debug.Log("<color=yellow>POT MENABRAK/MENYENTUH OBJEK:</color> " + collision.gameObject.name);
    }
}
