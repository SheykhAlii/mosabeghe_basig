using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
public class qrAngelReciver : MonoBehaviour
{
    public GameObject[] body;
    private List<string> lines;
    private int i = 0;
    private UdpClient udpClient;
    private Task listeningTask;
    private string receivedData = null;
    private IPEndPoint remoteEndPoint;
    public GameObject farrrmon;

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
           farrrmon.transform.eulerAngles = new Vector3(0, 0,float.Parse(receivedData));
           Debug.Log(receivedData);

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
