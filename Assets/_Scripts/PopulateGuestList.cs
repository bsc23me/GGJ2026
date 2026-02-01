using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopulateGuestList : MonoBehaviour
{

    public int numberOfGuests;

    public GuestProfile[] profiles;
    public Dictionary<int,GuestProfile> CompleteProfileList { get; private set; }
    [HideInInspector] public List<GuestProfile> profileList;

    [SerializeField] private GameObject lineItemPrefab;
    [SerializeField] private Transform lineItemParent;
    [SerializeField] private int lineSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CompleteProfileList = new Dictionary<int, GuestProfile>();
        profileList = new List<GuestProfile>();

       

        PopulateList();

        SetScrollSize();
    }

    void PopulateList()
    {
        for(int i = 0; i < profiles.Length; i++)
        {
            CompleteProfileList.Add(profiles[i].id,profiles[i]);
            if (!profiles[i].isIntruder)
                profileList.Add(profiles[i]);
        }
        for (int i = 0; i < numberOfGuests; i++)
        {
            GameObject lineItem = Instantiate(lineItemPrefab, lineItemParent);
            int j = Random.Range(0, profileList.Count);
            lineItem.GetComponent<GuestInfo>().profile = profileList[j];
            profileList.RemoveAt(j);
        }
    }

    void SetScrollSize()
    {
        lineItemParent.GetComponent<RectTransform>().sizeDelta =
            new Vector2(lineItemParent.GetComponent<RectTransform>().sizeDelta.x, lineSize * numberOfGuests);
    }
}
