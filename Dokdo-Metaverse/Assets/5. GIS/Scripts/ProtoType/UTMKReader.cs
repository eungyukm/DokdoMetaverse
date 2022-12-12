using UnityEngine;
using TMPro;

public class UTMKReader : MonoBehaviour
{
    private CoordConverter _coordConverter = new CoordConverter();

    public Vector3 hitPos = new Vector3();

    public TMP_InputField KCodeInputField;
    public TMP_InputField UtmkInputField;

    public string kcode = null;
    
    // 지면 좌표를 얻어 냅니다. 
    public void GetUTMK()
    {
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if(Physics.Raycast(ray, out hitData))
        {
            hitPos = hitData.point;
        }
    }
    
    // 월드 좌표를 입력 받아 국가 지점 좌표로 변환
    public void WorldPositionToKCode()
    {
        string kCode = _coordConverter.WorldPositonToKcodeInSaSa(hitPos.x, hitPos.z);
        KCodeInputField.text = kCode;
        kcode = kCode;
    }
    
    // 월드 좌표를 입력 받아 UTMK 좌표로 변환
    public void WorldPositionToUTMK()
    {
        string utmk = _coordConverter.WorldPositonToUTMKInSaSa(hitPos.x, hitPos.z);
        UtmkInputField.text = utmk;
    }
    
    void Update()
    {
        GetUTMK();
        WorldPositionToKCode();
        WorldPositionToUTMK();
    }
}
