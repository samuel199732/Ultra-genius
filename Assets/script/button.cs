using UnityEngine;
public class button:MonoBehaviour
{
    [SerializeField]
    private int id;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }
}
