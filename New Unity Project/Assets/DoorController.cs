using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Vector3 openRotation = new Vector3(0, 90, 0); // ✅ Open Rotation
    public float openSpeed = 2f; // ✅ Rotation Speed
    private bool isOpen = false;

    private void Start()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.onDoorOpened.AddListener(OpenDoor);
            Debug.Log("Event Listener Added to DoorController");
        }
        else
        {
            Debug.LogError("EventManager Instance is NULL!");
        }
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            Debug.Log("Door Rotating...");

            // ✅ Coroutine start karenge jo door ko smoothly rotate karega
            StartCoroutine(RotateDoor());

            isOpen = true;
        }
        else
        {
            Debug.Log("Door is already open!");
        }
    }

    private IEnumerator RotateDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(openRotation);
        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, time);
            time += Time.deltaTime * openSpeed;
            yield return null;
        }

        transform.rotation = endRotation;
        Debug.Log("Door Rotation Completed");
    }
}
