using UnityEngine;

public class SliderDoor : MonoBehaviour
{
    [SerializeField] private Animator[] anims;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject doorSprite;
    [SerializeField] private bool doorTrigger = false;

    public bool open = false;

    public void Start()
    {
        if (doorTrigger) OpenThePodBayDoors();
        sprite = transform.Find("DoorMarker").GetComponent<SpriteRenderer>();

        sprite.color = ColorChange(open);
    }

    public void OpenThePodBayDoors()
    {
        open = !open;
        sprite.color = ColorChange(open);
        for (int i = 0; i < anims.Length; i++)
        {
            // opens the door sliders using the animator
            anims[i].SetBool("DoorOpen", open);
        }
    }

    private Color ColorChange(bool _open)
    {
        switch (_open)
        {
            case true:
                doorSprite.SetActive(true);
                return Color.green;
            break;
            
            case false:
                doorSprite.SetActive(false);
                return Color.red;
            break;
        }
    }
}
