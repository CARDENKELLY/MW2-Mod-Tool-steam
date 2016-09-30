using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

public unsafe class ProcessMemory
{
    [DllImport("Kernel32.dll")]
    static extern Boolean ReadProcessMemory(IntPtr processHandle, IntPtr address, IntPtr bufferAddress, Int32 bufferLength, out Int32 BytesRead);
    [DllImport("Kernel32.dll")]
    static extern Boolean WriteProcessMemory(IntPtr processHandle, IntPtr address, IntPtr bufferAddress, Int32 bufferLength, out Int32 BytesWritten);
    [DllImport("Kernel32.dll")]
    static extern IntPtr VirtualAllocEx(IntPtr processHandle, IntPtr address, Int32 allocationSize, Int32 allocationType, Int32 protectionType);
    [DllImport("Kernel32.dll")]
    static extern Boolean VirtualFreeEx(IntPtr processHandle, IntPtr address, Int32 freeSize, Int32 freeType);
    [DllImport("Kernel32.dll")]
    static extern Boolean VirtualProtectEx(IntPtr processHandle, IntPtr address, Int32 protectSize, Int32 newProtectionType, out Int32 oldProtectionType);

    Int32 idc;

    public Process Owner { get; private set; }

    public ProcessMemory(Process owner)
    {
        Process.EnterDebugMode();
        Owner = owner;
    }

    /// <summary>
    /// Returns an array of ProcessMemory for all processes.
    /// </summary>
    /// <returns>An array of ProcessMemory for all processes.</returns>
    public static IEnumerable<ProcessMemory> GetProcesses()
    {
        Process.EnterDebugMode();
        foreach (var proc in Process.GetProcesses())
            yield return new ProcessMemory(proc);
    }

    /// <summary>
    /// Returns an array of ProcessMemory for processes that have the specified process name.
    /// </summary>
    /// <param name="processName">The process name of the target processes.</param>
    /// <returns>An array of ProcessMemory for processes that have the specified process name.</returns>
    public static IEnumerable<ProcessMemory> GetProcessesByName(String processName)
    {
        Process.EnterDebugMode();
        foreach (var proc in Process.GetProcessesByName(processName))
            yield return new ProcessMemory(proc);
    }

    /// <summary>
    /// Returns an array of ProcessMemory for processes that have the specified window name.
    /// </summary>
    /// <param name="windowName">The window name of the target processes.</param>
    /// <returns>An array of ProcessMemory for processes that have the specified window name.</returns>
    public static IEnumerable<ProcessMemory> GetProcessesByWindowName(String windowName)
    {
        Process.EnterDebugMode();
        foreach (var proc in Process.GetProcesses())
            if (proc.MainWindowTitle.ToLower() == windowName.ToLower())
                yield return new ProcessMemory(proc);
    }

    /// <summary>
    /// Returns an instance of ProcessMemory for the current process.
    /// </summary>
    /// <returns>An instance of ProcessMemory for the current process.</returns>
    public static ProcessMemory GetCurrentProcess()
    {
        Process.EnterDebugMode();
        return new ProcessMemory(Process.GetCurrentProcess());
    }

    /// <summary>
    /// Returns an instance of ProcessMemory for the specified process Id.
    /// </summary>
    /// <param name="processId">The process Id of the target process.</param>
    /// <returns>An instance of ProcessMemory for the specified process Id.</returns>
    public static ProcessMemory GetProcessById(Int32 processId)
    {
        Process.EnterDebugMode();
        return new ProcessMemory(Process.GetProcessById(processId));
    }

    /// <summary>
    /// Reads an array of type T from the specified address.
    /// </summary>
    /// <typeparam name="T">The element type of the array being read.</typeparam>
    /// <param name="address">The address to read from.</param>
    /// <param name="length">The number of elements to read.</param>
    /// <returns>An array of type T with the specified number of elements</returns>
    public T[] ReadArray<T>(IntPtr address, Int32 length)
    {
        Int32 elementSize = Marshal.SizeOf(typeof(T));
        Int32 oldProtection;
        T[] buffer = new T[length];

        GCHandle hBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        {
            if (!VirtualProtectEx(Owner.Handle, address, length, 0x40, out oldProtection))
                ThrowLastWin32Error();
            if (!ReadProcessMemory(Owner.Handle, address, hBuffer.AddrOfPinnedObject(), length * elementSize, out idc))
                ThrowLastWin32Error();
            if (!VirtualProtectEx(Owner.Handle, address, length, oldProtection, out oldProtection))
                ThrowLastWin32Error();
        }
        hBuffer.Free();

        return buffer;
    }

    /// <summary>
    /// Writes an array of type T to the specified address.
    /// </summary>
    /// <typeparam name="T">The element type of the array being written.</typeparam>
    /// <param name="address">The address to write to.</param>
    /// <param name="values">The elements to write.</param>
    public void WriteArray<T>(IntPtr address, params T[] values)
    {
        Int32 elementSize = Marshal.SizeOf(typeof(T));
        Int32 oldProtection;

        GCHandle hValues = GCHandle.Alloc(values, GCHandleType.Pinned);
        {
            if (!VirtualProtectEx(Owner.Handle, address, values.Length * elementSize, 0x40, out oldProtection))
                ThrowLastWin32Error();
            if (!WriteProcessMemory(Owner.Handle, address, hValues.AddrOfPinnedObject(), values.Length * elementSize, out idc))
                ThrowLastWin32Error();
            if (!VirtualProtectEx(Owner.Handle, address, values.Length * elementSize, oldProtection, out oldProtection))
                ThrowLastWin32Error();
        }
        hValues.Free();
    }

    /// <summary>
    /// Reads a value of type T from the specified address.
    /// </summary>
    /// <typeparam name="T">The type of value being read.</typeparam>
    /// <param name="address">The address to read from.</param>
    /// <returns>A value of type T read from the specified address.</returns>
    public T ReadValue<T>(IntPtr address)
    {
        return ReadArray<T>(address, 1)[0];
    }

    /// <summary>
    /// Writes a value of type T to the specified address.
    /// </summary>
    /// <typeparam name="T">The type of value being written.</typeparam>
    /// <param name="address">The address to write to.</param>
    /// <param name="value">The value to write.</param>
    public void WriteValue<T>(IntPtr address, T value)
    {
        WriteArray<T>(address, value);
    }

    /// <summary>
    /// Reads an ansi string. This function will automatically truncate after a null character.
    /// </summary>
    /// <param name="address">The address to read from.</param>
    /// <param name="length">Length of the string being read.</param>
    /// <returns>An ansi string read from the specified address.</returns>
    public String ReadStringA(IntPtr address, Int32 length = 32)
    {
        Byte[] buffer = ReadArray<Byte>(address, length);

        fixed (Byte* pBuffer = buffer)
        {
            return Marshal.PtrToStringAnsi((IntPtr)pBuffer);
        }
    }

    /// <summary>
    /// Reads a unicode string. This function will automatically truncate after a null character.
    /// </summary>
    /// <param name="address">The address to read from.</param>
    /// <param name="length">Length of the string being read.</param>
    /// <returns>A unicode string read from the specified address.</returns>
    public String ReadStringW(IntPtr address, Int32 length = 32)
    {
        Byte[] buffer = ReadArray<Byte>(address, length * 2);

        fixed (Byte* pBuffer = buffer)
        {
            return Marshal.PtrToStringUni((IntPtr)pBuffer);
        }
    }

    /// <summary>
    /// Writes an ansi string.
    /// </summary>
    /// <param name="address">The address to write to.</param>
    /// <param name="value">The value to write.</param>
    public void WriteStringA(IntPtr address, String value)
    {
        WriteArray<Byte>(address, Encoding.ASCII.GetBytes(value));
    }

    /// <summary>
    /// Writes a unicode string.
    /// </summary>
    /// <param name="address">The address to write to.</param>
    /// <param name="value">The value to write.</param>
    public void WriteStringW(IntPtr address, String value)
    {
        WriteArray<Byte>(address, Encoding.Unicode.GetBytes(value));
    }

    /// <summary>
    /// Allocates the specified amount of space in memory.
    /// </summary>
    /// <param name="allocationSize">The number of bytes to allocate.</param>
    /// <returns>Pointer to allocated space.</returns>
    public IntPtr Alloc(Int32 allocationSize)
    {
        IntPtr retVal = VirtualAllocEx(Owner.Handle, IntPtr.Zero, allocationSize, 0x3000, 0x40);

        if (retVal == IntPtr.Zero)
            ThrowLastWin32Error();

        WriteArray<Byte>(retVal, new Byte[allocationSize]);

        return retVal;
    }

    /// <summary>
    /// Allocates an array of type T.
    /// </summary>
    /// <typeparam name="T">The element type of the array being allocated.</typeparam>
    /// <param name="values">Values to allocate.</param>
    /// <returns>Pointer to allocated array.</returns>
    public IntPtr AllocArray<T>(params T[] values)
    {
        Int32 elementSize = Marshal.SizeOf(typeof(T));
        IntPtr retVal = Alloc(values.Length * elementSize);

        WriteArray<T>(retVal, values);
        return retVal;
    }

    /// <summary>
    /// Allocates a value of type T.
    /// </summary>
    /// <typeparam name="T">The type to allocate.</typeparam>
    /// <param name="value">Value to allocate.</param>
    /// <returns>Pointer to allocated value.</returns>
    public IntPtr AllocValue<T>(T value)
    {
        return AllocArray<T>(value);
    }

    /// <summary>
    /// Allocates an ansi string.
    /// </summary>
    /// <param name="value">Value to allocate.</param>
    /// <returns>Pointer to allocated string.</returns>
    public IntPtr AllocStringA(String value)
    {
        return AllocArray<Byte>(Encoding.ASCII.GetBytes(value + (char)0));
    }

    /// <summary>
    /// Allocates a unicode string.
    /// </summary>
    /// <param name="value">Value to allocate.</param>
    /// <returns>Pointer to allocated string.</returns>
    public IntPtr AllocStringW(String value)
    {
        return AllocArray<Byte>(Encoding.Unicode.GetBytes(value + (char)0));
    }

    /// <summary>
    /// Frees allocated space that was allocated using any of the variations of Alloc.
    /// </summary>
    /// <param name="address">Address returned by the alloc functions.</param>
    public void Free(IntPtr address)
    {
        if (!VirtualFreeEx(Owner.Handle, address, 0, 0x8000))
            ThrowLastWin32Error();
    }

    /// <summary>
    /// Throws the last Win32 error as a managed exception.
    /// </summary>
    static void ThrowLastWin32Error()
    {
        throw new Exception(String.Format("Win32 Error Code: {0:X8}", Marshal.GetLastWin32Error()));
    }
}