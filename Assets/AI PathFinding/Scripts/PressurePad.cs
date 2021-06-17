using System.Collections;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    #region Variables
    [SerializeField] private SliderDoor[] SecondaryDoors = null;
    private SliderDoor mainDoor;
    private BoxCollider box;
    #endregion
    #region Methods
    private void Awake()
    {
        mainDoor = GetComponentInParent<SliderDoor>();
        box = GetComponent<BoxCollider>();
    }
    /// <summary>
    /// Checks if the agent collided with the plate then triggers the door
    /// </summary>
    /// <param name="_other"></param>
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Agent"))
            StartCoroutine(DoorControl());
    }
    /// <summary>
    /// Waits for a time then Closes/Opens the door
    /// </summary>
    private IEnumerator DoorControl()
    {
        // waits then calls the door and disables the plate
        yield return new WaitForSeconds(0.5f);
        mainDoor.OpenThePodBayDoors();
        if (SecondaryDoors.Length > 0) 
            foreach (var t in SecondaryDoors)
                t.OpenThePodBayDoors();
        else Debug.LogWarning("No Secondary Door Found");

        // waits then calls the door and enables the plate
        // yield return  new WaitForSeconds(25);
        // control.OpenThePodBayDoors();
        // box.enabled = true;
    }
    #endregion
}
