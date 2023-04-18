
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    public int selectedPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedPlayer = selectedPlayer;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedPlayer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedPlayer = 1;
        }


        if (previousSelectedPlayer != selectedPlayer)
        {
            SelectPlayer();
        }   
    }

    void SelectPlayer()
    {
        int i = 0;
        foreach (Transform player in transform)
        {
            if (i == selectedPlayer)
                player.gameObject.SetActive(true);
            else
                player.gameObject.SetActive(false);
            i++;

        }
    }
}
