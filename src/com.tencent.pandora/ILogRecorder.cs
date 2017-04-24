using System;

namespace com.tencent.pandora
{
	internal interface ILogRecorder
	{
		void Add(Log log);

		void Dispose();
	}
}
