using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuestInfo : MonoBehaviour
{

    public GuestProfile profile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = profile.guestName;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GetDescriptors();
        transform.GetChild(2).GetComponent<Image>().sprite = profile.PFP;
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { });

    }

    string GetDescriptors()
    {
        string desc = string.Empty;
        List<string> descriptors = new List<string>();
        descriptors.AddRange(profile.descriptors);
        for (int i = 0; i < 3; i++)
        {
            if (descriptors.Count == 0)
                break;

            int j = Random.Range(0, descriptors.Count);
            desc += descriptors[j];
            if(i < 2)
                desc += "\n";
            descriptors.RemoveAt(j);

        }
        return desc;
    }

    public void SetDone()
    {
        transform.GetChild(4).gameObject.SetActive(true);
    }

}
