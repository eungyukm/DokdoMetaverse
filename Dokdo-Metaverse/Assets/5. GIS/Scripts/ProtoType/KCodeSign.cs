using TMPro;
using UnityEngine;

public class KCodeSign : MonoBehaviour
{
    public TMP_Text kCode1;
    public TMP_Text kCode2;

    public void SetKCode(string code)
    {
        kCode1.text = code;
        kCode2.text = code;
    }
}
