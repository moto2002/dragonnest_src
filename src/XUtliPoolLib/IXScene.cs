using System;

namespace XUtliPoolLib
{
	public interface IXScene
	{
		bool XSceneLoadScene(string scenename, Action<float> progress);

		bool XSceneIsDone();

		bool XSceneEnable(string scenename);
	}
}
