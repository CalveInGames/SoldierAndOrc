using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public Camera mainCamera;
    private bool isCharacter1Active;
    private CharacterMovement character1Movement;
    private CharacterMovement character2Movement;

    void Start()
    {
        isCharacter1Active = true;
        character1Movement = character1.GetComponent<CharacterMovement>();
        character2Movement = character2.GetComponent<CharacterMovement>();
        SwitchCharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCharacter1Active = !isCharacter1Active;
            SwitchCharacter();
        }

        // Update camera position to follow the active character
        if (isCharacter1Active)
        {
            mainCamera.transform.position = new Vector3(character1.transform.position.x, character1.transform.position.y, mainCamera.transform.position.z);
        }
        else
        {
            mainCamera.transform.position = new Vector3(character2.transform.position.x, character2.transform.position.y, mainCamera.transform.position.z);
        }
    }

    void SwitchCharacter()
    {
        // Toggle movement scripts
        character1Movement.enabled = isCharacter1Active;
        character2Movement.enabled = !isCharacter1Active;
    }
}