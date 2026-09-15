using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float kecepatan = 5f;
    private Vector2 arahGerak;

    [Header("Referensi")]
    public GameManager gameManager;

    void OnMove(InputValue value)
    {
        arahGerak = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0);
        transform.position += arah * kecepatan * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            if (gameManager != null)
            {
                gameManager.AmbilKoin();
            }
            else
            {
                Debug.LogWarning("GameManager belum dimasukkan ke slot Inspector Player!");
            }
        }
    }
}