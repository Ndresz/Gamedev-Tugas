using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    GameObject objCamera;
    AudioSource footstepSource;
    [SerializeField] AudioClip footstepClip;

    private void Start()
    {
        objCamera = this.transform.Find("Main Camera").gameObject;

        // Setup footstep audio source
        footstepSource = gameObject.AddComponent<AudioSource>();
        footstepSource.clip = footstepClip;
        footstepSource.loop = true;
        footstepSource.playOnAwake = false;
        footstepSource.spatialBlend = 0f;
        footstepSource.volume = 0.5f;
    }

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

        // Footstep sound: play when moving, stop when not
        bool isMoving = (v != 0);
        if (isMoving && !footstepSource.isPlaying)
        {
            footstepSource.Play();
        }
        else if (!isMoving && footstepSource.isPlaying)
        {
            footstepSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "areaMusuh")
        {
            objCamera.SendMessage("rubah_musik1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "areaMusuh")
        {
            objCamera.SendMessage("rubah_musik2");
        }
    }
}
