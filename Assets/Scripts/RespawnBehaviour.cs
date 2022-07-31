using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.livesManager();
            }

            CharacterController tempController = other.transform.GetComponent<CharacterController>();

            if(tempController != null)
            {
                tempController.enabled = false;
            }

            player.transform.position = _respawnLocation.transform.position;

            StartCoroutine(characterControllerEnabler(tempController));
        }   
    }

    IEnumerator characterControllerEnabler(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
