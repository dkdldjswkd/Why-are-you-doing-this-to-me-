using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButton : MonoBehaviour
{
    bool* ClickedButton = new bool[4];

    void Spawner1()
    {
        DefanceManager.SpawnerButtonDown = !DefanceManager.SpawnerButtonDown;
    }
}
