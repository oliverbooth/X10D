using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace X10D.Unity;

/// <summary>
///     An extended version of Unity's <see cref="UnityEngine.Debug" /> utility class which offers support for drawing simple
///     primitives.
/// </summary>
public static partial class DebugEx
{
    /// <summary>
    ///     The default value to use for the <c>duration</c> parameter.
    /// </summary>
    private const float DefaultDrawDuration = 0.0f;

    /// <summary>
    ///     The default value to use for the <c>depthTest</c> parameter.
    /// </summary>
    private const bool DefaultDepthTest = true;

    /// <summary>
    ///     Gets a value indicating whether this is a debug build.
    /// </summary>
    /// <value><see langword="true" /> if this is a debug build; otherwise, <see langword="false" />.</value>
    // ReSharper disable once InconsistentNaming
    public static bool isDebugBuild
    {
        get => Debug.isDebugBuild;
    }

    /// <summary>
    ///     Gets a value indicating whether the developer console is visible.
    /// </summary>
    /// <value><see langword="true" /> if the developer console is visible; otherwise, <see langword="false" />.</value>
    // ReSharper disable once InconsistentNaming
    public static bool isDeveloperConsoleVisible
    {
        get => Debug.developerConsoleVisible;
    }

    /// <summary>
    ///     Gets the default Unity debug logger.
    /// </summary>
    /// <value>The Unity debug logger.</value>
    // ReSharper disable once InconsistentNaming
    public static ILogger unityLogger
    {
        get => Debug.unityLogger;
    }

    /// <summary>
    ///     Asserts a condition.
    /// </summary>
    /// <param name="condition">The condition to assert.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [AssertionMethod]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void Assert(bool condition)
    {
        if (condition)
        {
            return;
        }

        unityLogger.Log(LogType.Assert, "Assertion failed");
    }

    /// <summary>
    ///     Asserts a condition.
    /// </summary>
    /// <param name="condition">The condition to assert.</param>
    /// <param name="context">The object to which the assertion applies.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [AssertionMethod]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void Assert(bool condition, Object context)
    {
        if (condition)
        {
            return;
        }

        unityLogger.Log(LogType.Assert, (object)"Assertion failed", context);
    }

    /// <summary>
    ///     Asserts a condition.
    /// </summary>
    /// <param name="condition">The condition to assert.</param>
    /// <param name="message">The message to log.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [AssertionMethod]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void Assert(bool condition, string? message)
    {
        if (condition)
        {
            return;
        }

        unityLogger.Log(LogType.Assert, message);
    }

    /// <summary>
    ///     Asserts a condition.
    /// </summary>
    /// <param name="condition">The condition to assert.</param>
    /// <param name="message">The message to log.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [AssertionMethod]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void Assert<T>(bool condition, T? message)
    {
        if (condition)
        {
            return;
        }

        unityLogger.Log(LogType.Assert, message?.ToString());
    }

    /// <summary>
    ///     Logs a message to the Unity Console.
    /// </summary>
    /// <param name="condition">The condition to assert.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the assertion applies.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [AssertionMethod]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void Assert(bool condition, string? message, Object? context)
    {
        if (condition)
        {
            return;
        }

        unityLogger.Log(LogType.Assert, (object?)message, context);
    }

    /// <summary>
    ///     Logs a message to the Unity Console.
    /// </summary>
    /// <param name="condition">The condition to assert.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the assertion applies.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [AssertionMethod]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void Assert<T>(bool condition, T? message, Object? context)
    {
        if (condition)
        {
            return;
        }

        unityLogger.Log(LogType.Assert, (object?)message?.ToString(), context);
    }

    /// <summary>
    ///     Pauses the editor.
    /// </summary>
    public static void Break()
    {
        Debug.Break();
    }

    /// <summary>
    ///     Clears the developer console.
    /// </summary>
    public static void ClearDeveloperConsole()
    {
        Debug.ClearDeveloperConsole();
    }

    /// <summary>
    ///     Populate an unmanaged buffer with the current managed call stack as a sequence of UTF-8 bytes, without allocating GC
    ///     memory.
    /// </summary>
    /// <param name="buffer">The target buffer to receive the callstack text.</param>
    /// <param name="bufferMax">The maximum number of bytes to write.</param>
    /// <param name="projectFolder">The project folder path, to clean up path names.</param>
    /// <returns>The number of bytes written into the buffer.</returns>
    [MustUseReturnValue("Fewer bytes may be returned than requested.")]
    public static unsafe int ExtractStackTraceNoAlloc(byte* buffer, int bufferMax, string projectFolder)
    {
        return Debug.ExtractStackTraceNoAlloc(buffer, bufferMax, projectFolder);
    }

    /// <summary>
    ///     Logs a message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Log(string? message)
    {
        Debug.Log(message);
    }

    /// <summary>
    ///     Logs a message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Log<T>(T message)
    {
        Log(message?.ToString());
    }

    /// <summary>
    ///     Logs a message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    public static void Log(string message, Object? context)
    {
        Debug.Log(message, context);
    }

    /// <summary>
    ///     Logs a message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    public static void Log<T>(T message, Object? context)
    {
        Debug.Log(message?.ToString(), context);
    }

    /// <summary>
    ///     Logs an assertion message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void LogAssertion(string? message)
    {
        unityLogger.Log(LogType.Assert, message);
    }

    /// <summary>
    ///     Logs an assertion message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void LogAssertion<T>(T message)
    {
        unityLogger.Log(LogType.Assert, message?.ToString());
    }

    /// <summary>
    ///     Logs an assertion message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void LogAssertion(string message, Object? context)
    {
        unityLogger.Log(LogType.Assert, (object?)message, context);
    }

    /// <summary>
    ///     Logs an assertion message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    [Conditional("UNITY_ASSERTIONS")]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public static void LogAssertion<T>(T? message, Object? context)
    {
        unityLogger.Log(LogType.Assert, (object?)message?.ToString(), context);
    }

    /// <summary>
    ///     Logs an error message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void LogError(string? message)
    {
        Debug.LogError(message);
    }

    /// <summary>
    ///     Logs an error message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void LogError<T>(T? message)
    {
        LogError(message?.ToString());
    }

    /// <summary>
    ///     Logs an error message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    public static void LogError(string message, Object? context)
    {
        Debug.LogError(message, context);
    }

    /// <summary>
    ///     Logs an error message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    public static void LogError<T>(T? message, Object? context)
    {
        Debug.LogError(message?.ToString(), context);
    }

    /// <summary>
    ///     Logs a formatted error message to the Unity Console.
    /// </summary>
    /// <param name="format">The format string of the message to log.</param>
    /// <param name="args">The format arguments.</param>
    public static void LogErrorFormat(string? format, params object?[]? args)
    {
        Debug.LogErrorFormat(format, args);
    }

    /// <summary>
    ///     Logs a formatted error message to the Unity Console.
    /// </summary>
    /// <param name="context">The object to which this message applies.</param>
    /// <param name="format">The format string of the message to log.</param>
    /// <param name="args">The format arguments.</param>
    public static void LogErrorFormat(Object context, string? format, params object?[]? args)
    {
        Debug.LogErrorFormat(context, format, args);
    }

    /// <summary>
    ///     Logs a formatted message to the Unity Console.
    /// </summary>
    /// <param name="format">The format string of the message to log.</param>
    /// <param name="args">The format arguments.</param>
    public static void LogFormat(string? format, params object?[]? args)
    {
        Debug.LogFormat(format, args);
    }

    /// <summary>
    ///     Logs a formatted message to the Unity Console.
    /// </summary>
    /// <param name="context">The object to which this message applies.</param>
    /// <param name="format">The format string of the message to log.</param>
    /// <param name="args">The format arguments.</param>
    public static void LogFormat(Object context, string? format, params object?[]? args)
    {
        Debug.LogFormat(context, format, args);
    }

    /// <summary>
    ///     Logs a warning message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void LogWarning(string? message)
    {
        Debug.LogWarning(message);
    }

    /// <summary>
    ///     Logs a warning message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void LogWarning<T>(T? message)
    {
        LogWarning(message?.ToString());
    }

    /// <summary>
    ///     Logs a warning message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    public static void LogWarning(string message, Object? context)
    {
        Debug.LogWarning(message, context);
    }

    /// <summary>
    ///     Logs a warning message to the Unity Console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The object to which the message applies.</param>
    public static void LogWarning<T>(T? message, Object? context)
    {
        Debug.LogWarning(message?.ToString(), context);
    }

    /// <summary>
    ///     Logs a formatted warning message to the Unity Console.
    /// </summary>
    /// <param name="format">The format string of the message to log.</param>
    /// <param name="args">The format arguments.</param>
    public static void LogWarningFormat(string? format, params object?[]? args)
    {
        Debug.LogWarningFormat(format, args);
    }

    /// <summary>
    ///     Logs a formatted warning message to the Unity Console.
    /// </summary>
    /// <param name="context">The object to which this message applies.</param>
    /// <param name="format">The format string of the message to log.</param>
    /// <param name="args">The format arguments.</param>
    public static void LogWarningFormat(Object context, string? format, params object?[]? args)
    {
        Debug.LogWarningFormat(context, format, args);
    }
}
