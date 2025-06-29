using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using System;

public class YTresiver : MonoBehaviour
{
    Thread thread;
    public int connectionPort = 25001;
    TcpListener server;
    TcpClient client;
    bool running;

    public GameObject[] body;
    
    int i =0;

    void Start()
    {
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();
    }

    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            Connection();
        }
        server.Stop();
    }

    public string Connection()
    {
        // Read data from the network stream
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

        // Decode the bytes into a string
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        
        // Make sure we're not getting an empty string

        //dataReceived.Trim();
        
        return dataReceived;
    }

    // Use-case specific function, need to re-write this to interpret whatever data is being sent
    

    // Position is the data being received in this example
    

    void Update()
    {



Console.WriteLine(Connection());
    }
    }

        /*
        // Set this object's position in the scene according to the position received
        string result;

    //result = Connection();


    string[] Points = Connection().Split(',');

    for(int i = 0 ; i<=32;i++){



    float x = float.Parse(Points[0+ (i*3)])/-100;
    float y = float.Parse(Points[1+ (i*3)])/-100;
    float z = float.Parse(Points[2+ (i*3)])/100;
    body[i].transform.localPosition=new Vector3(x,y,0);
    }
    }
}    
    */