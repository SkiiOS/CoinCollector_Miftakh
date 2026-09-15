using UnityEngine;

// PENERIMA EVENT (Event Receiver / Subscriber / Listener)
// Script ini MENUNGGU sinyal dari PemancarEvent.TekanTombol.
public class receiverEvent : MonoBehaviour
{
    void OnEnable()
    {
        // Langganan (subscribe): daftarkan method agar dipanggil saat event.
        PemancarEvent.TekanTombol += TampilkanPesan;
    }

    void OnDisable()
    {
        // Berhenti langganan (unsubscribe) supaya tidak double-fire saat object direset
        PemancarEvent.TekanTombol -= TampilkanPesan;
    }

    void TampilkanPesan()
    {
        Debug.Log("Tombol telah ditekan!");
    }
}