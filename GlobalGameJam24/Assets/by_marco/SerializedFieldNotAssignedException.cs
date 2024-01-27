#nullable enable

using System;
using System.Runtime.CompilerServices;

public class SerializedFieldNotAssignedException : Exception
{
	public SerializedFieldNotAssignedException([CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "")
		: base($"The Serialized Field '{callerMemberName}' of {callerFilePath} has not been assigned in the inspector")
	{
	}

	public static void ThrowIfNull(object? objectToTest, string objectName)
	{
		if(objectToTest == null)
		{
			throw new SerializedFieldNotAssignedException(nameof(objectToTest), objectName);
		}
	}
}

