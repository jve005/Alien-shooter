using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 10f;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
