using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LuaInterface
{
	public static class LuaRegistrationHelper
	{
		public static void TaggedInstanceMethods(LuaState lua, object o)
		{
			if (lua == null)
			{
				throw new ArgumentNullException("lua");
			}
			if (o == null)
			{
				throw new ArgumentNullException("o");
			}
			MethodInfo[] methods = o.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < methods.Length; i++)
			{
				MethodInfo methodInfo = methods[i];
				object[] customAttributes = methodInfo.GetCustomAttributes(typeof(LuaGlobalAttribute), true);
				for (int j = 0; j < customAttributes.Length; j++)
				{
					LuaGlobalAttribute luaGlobalAttribute = (LuaGlobalAttribute)customAttributes[j];
					if (string.IsNullOrEmpty(luaGlobalAttribute.Name))
					{
						lua.RegisterFunction(methodInfo.Name, o, methodInfo);
					}
					else
					{
						lua.RegisterFunction(luaGlobalAttribute.Name, o, methodInfo);
					}
				}
			}
		}

		public static void TaggedStaticMethods(LuaState lua, Type type)
		{
			if (lua == null)
			{
				throw new ArgumentNullException("lua");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!type.IsClass)
			{
				throw new ArgumentException("The type must be a class!", "type");
			}
			MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
			for (int i = 0; i < methods.Length; i++)
			{
				MethodInfo methodInfo = methods[i];
				object[] customAttributes = methodInfo.GetCustomAttributes(typeof(LuaGlobalAttribute), false);
				for (int j = 0; j < customAttributes.Length; j++)
				{
					LuaGlobalAttribute luaGlobalAttribute = (LuaGlobalAttribute)customAttributes[j];
					if (string.IsNullOrEmpty(luaGlobalAttribute.Name))
					{
						lua.RegisterFunction(methodInfo.Name, null, methodInfo);
					}
					else
					{
						lua.RegisterFunction(luaGlobalAttribute.Name, null, methodInfo);
					}
				}
			}
		}

		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The type parameter is used to select an enum type")]
		public static void Enumeration<T>(LuaState lua)
		{
			if (lua == null)
			{
				throw new ArgumentNullException("lua");
			}
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsEnum)
			{
				throw new ArgumentException("The type must be an enumeration!");
			}
			string[] names = Enum.GetNames(typeFromHandle);
			T[] array = (T[])Enum.GetValues(typeFromHandle);
			lua.NewTable(typeFromHandle.Name);
			for (int i = 0; i < names.Length; i++)
			{
				string fullPath = typeFromHandle.Name + "." + names[i];
				lua[fullPath] = array[i];
			}
		}
	}
}
