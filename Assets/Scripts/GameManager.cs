using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI skorText;
    public TextMeshProUGUI menangText;

    [Header("Data Koin (Coin Collector)")]
    [HideInInspector]
    public int totalKoin;
    private int koinTerkumpul = 0;

    [Header("Data Skor Zombie (Modul Event)")]
    [SerializeField] private int skor = 0;

    // --- BERLANGGANAN EVENT (Modul Fase 3 Sesi 1) ---
    void OnEnable()
    {
        Enemy.OnZombieMati += TambahSkorSaatZombieMati;
    }

    void OnDisable()
    {
        Enemy.OnZombieMati -= TambahSkorSaatZombieMati;
    }

    void TambahSkorSaatZombieMati(Enemy zombieYangMati)
    {
        skor += 10;
        Debug.Log("Skor: " + skor);
        UpdateUISkor();
    }
    // ------------------------------------------------

    void Start()
    {
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (menangText != null)
            menangText.gameObject.SetActive(false);

        UpdateUISkor();
    }

    public void AmbilKoin()
    {
        koinTerkumpul++;
        UpdateUISkor();

        if (koinTerkumpul >= totalKoin && totalKoin > 0)
        {
            Menang();
        }
    }

    void UpdateUISkor()
    {
        if (skorText != null)
        {
            skorText.text = "Koin: " + koinTerkumpul + " / " + totalKoin + " | Skor: " + skor;
        }
    }

    void Menang()
    {
        if (menangText != null)
        {
            menangText.text = "KAMU MENANG!";
            menangText.gameObject.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}