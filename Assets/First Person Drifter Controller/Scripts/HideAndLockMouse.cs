using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndLockMouse : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
