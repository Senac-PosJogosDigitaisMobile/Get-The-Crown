using UnityEngine;
using System.Collections;

public class HT_Credits : MonoBehaviour
{

    public HT_GameController gameController;

    void OnMouseDown()
    {
        gameController.Credits();
    }
}
