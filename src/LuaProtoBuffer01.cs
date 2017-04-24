using System;
using UnityEngine;

public class LuaProtoBuffer01 : MonoBehaviour
{
	private string script = "      \r\n        function decoder()  \r\n            local msg = person_pb.Person()\r\n            local length = #TestProtol.data\r\n            msg:ParseFromString(TestProtol.data,length)\r\n            print('id:'..msg.id..' name:'..msg.name..' email:'..msg.email)\r\n        end\r\n\r\n        function encoder()                           \r\n            local msg = person_pb.Person()\r\n            msg.id = 100\r\n            msg.name = 'foo'\r\n            msg.email = 'bar'\r\n            local pb_data = msg:SerializeToString()\r\n            TestProtol.data = pb_data\r\n        end\r\n        ";

	private void Start()
	{
	}
}
