using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using JetBrains.Annotations;

public class resiver1 : MonoBehaviour
{

    public GameObject[] body;
    List<string> lines;
    int i =0;
    // Start is called before the first frame update
void Start()

{
    TcpListener server = null;


IPAddress localAddr = IPAddress.Parse("127.0.0.1");
int port = 8080;
server = new TcpListener(localAddr, port);
server.Start();


}






// Update is called once per frame
void Update()
{
string result;

result = reciver();


string[] Points = reciver().Split(',');

for(int i = 0 ; i<=2;i++){



float x = float.Parse(Points[0+ (i*3)])/-100;
float y = float.Parse(Points[1+ (i*3)])/-100;
float z = float.Parse(Points[2+ (i*3)])/100;
body[i].transform.localPosition=new Vector3(x,y,0);
}
}

public string reciver()
{
TcpListener server = null;
try
{
IPAddress localAddr = IPAddress.Parse("127.0.0.1");
int port = 8080;
server = new TcpListener(localAddr, port);
server.Start();


TcpClient client = server.AcceptTcpClient();
using (NetworkStream stream = client.GetStream())
{
byte[] buffer = new byte[1024];
int bytesRead = stream.Read(buffer, 0, buffer.Length);
string receivedString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
//Console.WriteLine($"Received: {receivedString}");

return receivedString;

client.Close();
}
}
catch (SocketException e)
{
//Console.WriteLine($"SocketException: {e}");
}
finally
{
server?.Stop();
}

Console.WriteLine("\nHit enter to continue...");
Console.Read();
return null;
}
}