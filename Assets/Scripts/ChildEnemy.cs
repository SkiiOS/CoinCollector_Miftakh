using UnityEngine;

public class ChildEnemy : Enemy
{
    public bool flag = true;

    public override void Serang()
    {
        Debug.Log("Child Enemy Menyerang!");
    }
}