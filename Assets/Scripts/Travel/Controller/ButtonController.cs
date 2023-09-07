using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public PlayerScript playerScript;

    public void MoveLeft()
    {
        Debug.Log("'A' button pressed (emulated)");
        playerScript.MoveLeft();
    }

    public void MoveRight()
    {
        Debug.Log("'D' button pressed (emulated)");
        playerScript.MoveRight();
    }
}
