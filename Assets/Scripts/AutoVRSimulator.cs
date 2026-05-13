using UnityEngine;
using UnityEngine.XR;

public class AutoVRSimulator : MonoBehaviour
{
    void Start()
    {
        // Mengecek apakah ada Headset VR yang tersambung dan nyala
        if (XRSettings.isDeviceActive)
        {
            Debug.Log("<b>[AutoVRSimulator]</b> Headset VR terdeteksi! Mematikan kontrol Keyboard & Mouse.");
            // Matikan objek XR Device Simulator ini agar tidak bentrok dengan VR asli
            gameObject.SetActive(false); 
        }
        else
        {
            Debug.Log("<b>[AutoVRSimulator]</b> Tidak ada Headset VR. Mengaktifkan kontrol Keyboard & Mouse.");
            // Biarkan objek ini tetap menyala
        }
    }
}
