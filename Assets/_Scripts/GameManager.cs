using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private PopulateGuestList populateGuestList;

    private int currentGuest;
    private int totalGuestsAndIntruders;
    private List<GuestProfile> roundProfiles;

    [SerializeField] private SpriteRenderer guestRenderer;
    [SerializeField] private SpriteRenderer maskRenderer;

    public void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        populateGuestList = GetComponent<PopulateGuestList>();
        roundProfiles = new List<GuestProfile>();

        GenerateRoundProfiles(totalGuestsAndIntruders);
    }

    public void SelectGuest(int id)
    {
        if (currentGuest == id)
        {

        }
    }

    void GenerateRoundProfiles(int numberOfGuests)
    {
        for (int i = 0; i < roundProfiles.Count - numberOfGuests; i++)
        {
            int j = Random.Range(0, roundProfiles.Count);
            roundProfiles.RemoveAt(j);
        }
    }

    void SendNextGuest()
    {
        int j = Random.Range(0, roundProfiles.Count);

    }
}
