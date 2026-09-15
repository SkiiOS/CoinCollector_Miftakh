using System;
using UnityEngine;
using UnityEngine.UI;

// PEMANCAR EVENT (Event Emitter / Publisher)
// Script ini BERTUGAS memicu (trigger) event 'TekanTombol' lewat tombol UI.
// Siapa pun yang 'subscribe' (receiverEvent) akan otomatis dipanggil.
public class PemancarEvent : MonoBehaviour
{
    // Deklare event. 'event' + delegate bawaan System.Action.
    public static event Action TekanTombol;

    [Header("UI")]
    public Button tombol;

    void OnEnable()
    {
        // Pasang pendengar klik tombol.
        if (tombol != null)
        {
            tombol.onClick.AddListener(EmitirEvent);
        }
    }

    void OnDisable()
    {
        // Jangan lupa lepas pendengar supaya tidak bocor / double-fire.
        if (tombol != null)
        {
            tombol.onClick.RemoveListener(EmitirEvent);
        }
    }

    void EmitirEvent()
    {
        Debug.Log("Pemancar: tombol diklik, event ditembakkan!");
        TekanTombol?.Invoke(); // '?' aman walau belum ada yang subscribe
    }
}