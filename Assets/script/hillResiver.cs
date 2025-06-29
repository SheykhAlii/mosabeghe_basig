using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class hillResiver : MonoBehaviour
{
    public GameObject[] body;
    private List<string> lines;
    private int i = 0;
    private UdpClient udpClient;
    private Task listeningTask;
    private string receivedData = null;
    private IPEndPoint remoteEndPoint;

    // Start is called before the first frame update
    void Start()
    {
        lines = new List<string>();
        int port = 8080;
        udpClient = new UdpClient(port);
        remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

        listeningTask = Task.Run(() => ListenForData());
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(receivedData))
        {
            string[] Points = receivedData.Split(',');

            for (int i = 0; i <= 2; i++)
            {
                float x = float.Parse(Points[0 + (i * 3)]) / -100;
                float y = float.Parse(Points[1 + (i * 3)]) / -100;
                float z = float.Parse(Points[2 + (i * 3)]) / 100;
                body[i].transform.localPosition = new Vector3(x, y, 0);
            }

            receivedData = null; // Reset the data after processing
        }
    }

    private async Task ListenForData()
    {
        try
        {
            while (true)
            {
                UdpReceiveResult result = await udpClient.ReceiveAsync();
                receivedData = Encoding.UTF8.GetString(result.Buffer);
            }
        }
        catch (SocketException e)
        {
            Debug.LogError($"SocketException: {e}");
        }
        finally
        {
            udpClient?.Close();
        }
    }

    private void OnApplicationQuit()
    {
        udpClient?.Close();
    }
}
