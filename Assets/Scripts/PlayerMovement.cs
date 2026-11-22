using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        float h = 0, v = 0;

        if (Keyboard.current.aKey.isPressed)
        {
            h = -1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            h = 1;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            v = 1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            v = -1;
        }

        this.transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * 3f);
        this.transform.Rotate(Vector3.up * h * 3f);
    }
}
