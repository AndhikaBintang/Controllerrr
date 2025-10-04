using UnityEngine;
using System.IO.Ports;

public class MPUReader : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM12", 115200);
    public float qw, qx, qy, qz;
    public float pitch;

    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 50;
    }

    void Update()
    {
        try
        {
            string line = serial.ReadLine();
            string[] data = line.Split(',');

            if (data.Length >= 4)
            {
                qw = float.Parse(data[0]);
                qx = float.Parse(data[1]);
                qy = float.Parse(data[2]);
                qz = float.Parse(data[3]);

                // Hitung pitch dari quaternion
                float sinp = 2f * (qw * qy - qz * qx);
                sinp = Mathf.Clamp(sinp, -1f, 1f);
                pitch = Mathf.Asin(sinp) * Mathf.Rad2Deg;
            }
        }
        catch { /* Abaikan error parsing */ }
    }
}
