using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private PopulateGuestList populateGuestList;

    private int currentGuest;
    [SerializeField] private int totalGuestsAndIntruders;
    private List<GuestProfile> roundProfiles;

    [SerializeField] private SpriteRenderer guestRenderer;
    [SerializeField] private SpriteRenderer maskRenderer;

    private int guestAnnoyances;
    [SerializeField] private int maxGuestAnnoyances;

    private int strikes;
    [SerializeField] private int maxStrikes;

    private int guestsEntered;

    [SerializeField] private TextMeshProUGUI guestStatements;

    private List<string> statements;

    public void Awake()
    {
        if(instance == null)
            instance = this;
    }
    // t
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        populateGuestList = GetComponent<PopulateGuestList>();
        roundProfiles = new List<GuestProfile>();
        statements = new List<string>();
        GenerateRoundProfiles(totalGuestsAndIntruders);

        SendNextGuest();
    }

    public void SelectGuest(int id)
    {
        Debug.Log("Selected " + populateGuestList.CompleteProfileList[id].guestName);
        if (currentGuest == id)
        {
            // TODO: punish for intruder
            guestsEntered++;
            if (guestsEntered < populateGuestList.numberOfGuests)
                SendNextGuest();
            else // WIN
                SceneManager.LoadScene(2);
        }
        else
        {
            guestAnnoyances++;
            if (guestAnnoyances >= maxGuestAnnoyances)
            {
                strikes++;
                if(strikes < maxStrikes)
                    SendNextGuest();
                else // LOSE
                    SceneManager.LoadScene(3);
            }
            else
            {
                GetNextStatement();
            }
        }
    }

    void GenerateRoundProfiles(int numberOfGuests)
    {
        roundProfiles.AddRange(populateGuestList.profiles);
        //Debug.Log("RoundProfiles: "+roundProfiles.Count);
        int toRemove = roundProfiles.Count - numberOfGuests;
        for (int i = 0; i < toRemove; i++)
        {
            int j = Random.Range(0, roundProfiles.Count);
            roundProfiles.RemoveAt(j);
        }
        //Debug.Log("RoundProfiles: "+roundProfiles.Count);
    }

    void SendNextGuest()
    {
        guestAnnoyances = 0;
        int j = Random.Range(0, roundProfiles.Count);
        currentGuest = roundProfiles[j].id;
        AddGuestStatements(roundProfiles[j]);
        GetNextStatement();
    }

    void AddGuestStatements(GuestProfile profile)
    {
        statements.Clear();
        statements.AddRange(profile.statements);
    }

    void GetNextStatement()
    {
        if (statements.Count > 0)
        {
            int j = Random.Range(0, statements.Count);
            guestStatements.text = statements[j];
            statements.RemoveAt(j);
        }
        else
        {
            guestStatements.text = "...";
        }
    }
}
