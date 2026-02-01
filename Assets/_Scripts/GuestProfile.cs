using UnityEngine;

[CreateAssetMenu(fileName = "GuestProfile", menuName = "Scriptable Objects/GuestProfile")]
public class GuestProfile : ScriptableObject
{

    public int id;
    public Sprite guestImage;
    public Sprite PFP;
    public string guestName;
    public string[] descriptors;
    public string[] statements;
    public string bouncerThoughts;

}
