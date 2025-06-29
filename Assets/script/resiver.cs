using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using JetBrains.Annotations;

public class resiver : MonoBehaviour
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

for(int i = 0 ; i<=32;i++){



float x = float.Parse(Points[0+ (i*3)])/-100;
float y = float.Parse(Points[1+ (i*3)])/-100;
float z = float.Parse(Points[2+ (i*3)])/100;
body[i].transform.localPosition=new Vector3(x,y,0);
}
/*float x1 = float.Parse(Points[3])/100;
float y1 = float.Parse(Points[4])/1000;
float z1 = float.Parse(Points[5])/100;
float x2 = float.Parse(Points[6])/100;
float y2 = float.Parse(Points[7])/100;
float z2 = float.Parse(Points[8])/100;
float x3 = float.Parse(Points[9])/100;
float y3 = float.Parse(Points[10])/1000;
float z3 = float.Parse(Points[11])/100;
float x4 = float.Parse(Points[12])/100;
float y4 = float.Parse(Points[13])/100;
float z4 = float.Parse(Points[14])/100;
float x5 = float.Parse(Points[15])/100;
float y5 = float.Parse(Points[16])/1000;
float z5 = float.Parse(Points[17])/100;
float x6 = float.Parse(Points[18])/100;
float y6 = float.Parse(Points[19])/100;
float z6 = float.Parse(Points[20])/100;
float x7 = float.Parse(Points[21])/100;
float y7 = float.Parse(Points[22])/1000;
float z7 = float.Parse(Points[23])/100;
float x8 = float.Parse(Points[24])/100;
float y8 = float.Parse(Points[25])/100;
float z8 = float.Parse(Points[26])/100;
float x9 = float.Parse(Points[27])/100;
float y9 = float.Parse(Points[28])/1000;
float z9 = float.Parse(Points[29])/100;
float x10 = float.Parse(Points[30])/100;
float y10 = float.Parse(Points[31])/100;
float z10 = float.Parse(Points[32])/100;
float x11 = float.Parse(Points[33])/100;
float y11 = float.Parse(Points[4])/1000;
float z11 = float.Parse(Points[5])/100;*/



/*body[1].transform.localPosition=new Vector3(x1,y1,z1);
body[2].transform.localPosition=new Vector3(x2,y2,z2);
body[3].transform.localPosition=new Vector3(x3,y3,z3);
body[4].transform.localPosition=new Vector3(x4,y4,z4);
body[5].transform.localPosition=new Vector3(x5,y5,z5);
body[6].transform.localPosition=new Vector3(x6,y6,z6);
body[7].transform.localPosition=new Vector3(x7,y7,z7);
body[8].transform.localPosition=new Vector3(x8,y8,z8);
body[9].transform.localPosition=new Vector3(x9,y9,z9);
body[10].transform.localPosition=new Vector3(x10,y1,z1);
body[11].transform.localPosition=new Vector3(x1,y1,z1);
body[12].transform.localPosition=new Vector3(x1,y1,z1);*/




//Debug.Log(result);





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

//Console.WriteLine("\nHit enter to continue...");
//Console.Read();
return null;
}
}