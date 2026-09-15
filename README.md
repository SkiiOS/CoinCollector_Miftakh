# CoinCollector Miftakh (PPLG 2)

Game 2D **Coin Collector** buatan Unity — player mengumpulkan koin sambil dihindari/dikejar zombie. Project tugas PPLG 2 (implementasi materi **OOP** dan **Delegate & Events**).

---

## Identitas

| Nama | Kelas |
|------|-------|
| Miftakh | XI PPLG 2 |


## Fitur / Ketentuan yang Dipenuhi

| Ketentuan Guru | Implementasi di Project | File |
|---|---|---|
| **GameManager** | Mengelola total koin, skor, kondisi menang, dan bergabung ke event mati zombie | `GameManager.cs` |
| **PlayerMovement** | Gerak player pakai Input System, ambil koin lewat trigger | `PlayerMovement.cs` |
| **OOP - Inheritance** | `ChildEnemy` mewarisi `Enemy` | `ChildEnemy.cs` → `Enemy.cs` |
| **OOP - Polymorphism** | Method `Serang()` dioverride di `ChildEnemy` | `ChildEnemy.cs` |
| **OOP - Abstraction** | Interface `IDamageable` yang diimplementasikan `Enemy` | `IDamageable.cs` |
| **State (min. 4)** | State machine zombie: `IDLE`, `PATROL`, `CHASE`, `ATTACK` | `StateZombie.cs` + `Enemy.cs` |
| **Delegate** | Contoh delegate `AksiDelegate` + `Action` | `Event/belajarDelegate.cs` |
| **Pemancar Event** | `PemancarEvent` menembak event `TekanTombol` (event `Action` + UnityButton) | `Event/PemancarEvent.cs` |
| **Penerima Event** | `receiverEvent` berlangganan `TekanTombol` | `Event/receiverEvent.cs` |

---

## Cara Setup (Unity)

1. Buka project di **Unity (versi sesuai ProjectVersion)**.
2. Buka scene utama.
3. **Event Button (tambahan)** — agar modul Event bisa diuji:
   - Buat tombol lewat **UI → Button** di scene.
   - Taruh script `PemancarEvent` ke sebuah GameObject (mis. object `EventManager`).
   - Ambil tombol tadi dan masukkan ke slot **Tombol** pada `PemancarEvent`.
   - Letakkan `receiverEvent` pada GameObject yang sama (atau objek lain).
   - Coba *Play* → klik tombol → Console akan muncul *"Pemancar: tombol diklik..."* dan *"Tombol telah ditekan!"*.
4. **Zombie (tambahan)**:
   - Taruh `Enemy` (base) atau `ChildEnemy` (turunannya) pada object zombie.
   - Pastikan ada player dengan tag `Player`.
   - Cek di Console log perpindahan state (`PATROL`, `CHASE`, `ATTACK`).

---

## Struktur Script

```
Assets/Scripts/
├── GameManager.cs
├── PlayerMovement.cs
├── IDamageable.cs          (interface)
├── Enemy.cs                (base, implements IDamageable, punya event + state)
├── ChildEnemy.cs           (inheritance + override)
├── StateZombie.cs          (enum state machine)
└── Event/
    ├── belajarDelegate.cs
    ├── PemancarEvent.cs
    └── receiverEvent.cs
```

---

## Gameplay Singkat

- Gerak player pakai **WASD / panah** (Input System).
- Sentuh **koin** → koin hilang, koin terkumpul bertambah.
- Kumpulkan semua koin → layar **"KAMU MENANG!"**.
- Zombie punya 4 state: diam → patrol → mengejar → menyerang.
- Saat zombie mati, event `OnZombieMati` menambah skor ke `GameManager`.
