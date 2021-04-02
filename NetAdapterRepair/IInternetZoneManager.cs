using System.Runtime.InteropServices;
using System;
using System.Text;
public enum UrlZone
{
    LocalMachine,
    Intranet,
    Trusted,
    Internet,
    Untrusted
}

public enum UrlAction
{
    ActiveXScriptletRun = unchecked((int)0x00001209),
    DownloadUnsignedActiveX = unchecked((int)0x00001004)
}

public enum UrlZoneReg
{
    Default,
    LocalMachineKey,
    CurrentUserKey
}

public enum URLTEMPLATE
{
    URLTEMPLATE_CUSTOM = 0x00000,
    URLTEMPLATE_PREDEFINED_MIN = 0x10000,
    URLTEMPLATE_LOW = 0x10000,
    URLTEMPLATE_MEDLOW = 0x10500,
    URLTEMPLATE_MEDIUM = 0x11000,
    URLTEMPLATE_MEDHIGH = 0x11500,
    URLTEMPLATE_HIGH = 0x12000,
    URLTEMPLATE_PREDEFINED_MAX = 0x20000
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct ZoneAttributes
{
    public uint Size;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string DisplayName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
    public string Description;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string IconPath;
    public uint TemplateMinLevel;
    public uint TemplateRecommended;
    public uint TemplateCurrentLevel;
    public uint Flags;
};

[ComImport,
 Guid("79eac9ef-baf9-11ce-8c82-00aa004ba90b"),
 InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IInternetZoneManager
{
    [PreserveSig]
    int GetZoneAttributes(uint dwZone,
                  ref ZoneAttributes pZoneAttributes);

    [PreserveSig]
    int SetZoneAttributes(uint dwZone,
                  ref ZoneAttributes pZoneAttributes);

    [PreserveSig]
    int GetZoneCustomPolicy(uint dwZone,
                ref Guid guidKey,
                out IntPtr ppPolicy,
                ref uint pcbPolicy,
                uint urlZoneReg);

    [PreserveSig]
    int SetZoneCustomPolicy(uint dwZone,
                ref Guid guidKey,
                IntPtr pPolicy,
                uint cbPolicy,
                uint urlZoneReg);

    [PreserveSig]
    int GetZoneActionPolicy(uint dwZone,
                uint dwAction,
                IntPtr pPolicy,
                uint cbPolicy,
                uint urlZoneReg);

    [PreserveSig]
    int SetZoneActionPolicy(uint dwZone,
                uint dwAction,
                IntPtr pPolicy,
                uint cbPolicy,
                uint urlZoneReg);

    [PreserveSig]
    int PromptAction(uint dwAction,
             HandleRef hwndParent,
             StringBuilder pwszUrl,
             StringBuilder pwszText,
             uint dwPromptFlags);

    [PreserveSig]
    int LogAction(uint dwAction,
              StringBuilder pwszUrl,
              StringBuilder pwszText,
              uint dwLogFlags);

    [PreserveSig]
    int CreateZoneEnumerator(ref uint pdwEnum,
                 ref uint pdwCount,
                 uint dwFlags);

    [PreserveSig]
    int GetZoneAt(uint dwEnum,
              uint dwIndex,
              ref uint pdwZone);

    [PreserveSig]
    int DestroyZoneEnumerator(uint dwEnum);

    [PreserveSig]
    int CopyTemplatePoliciesToZone(uint dwTemplate,
                       uint dwZone,
                       uint dwReserved);
}



public sealed class InternetZoneManager : IDisposable
{
    private IInternetZoneManager izm;

    public InternetZoneManager()
    {
        this.izm = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("7b8a2d95-0ac9-11d1-896c-00c04Fb6bfc4"))) as IInternetZoneManager;
    }

    public ZoneAttributes GetZoneAttributes(UrlZone zone)
    {
        ZoneAttributes za = new ZoneAttributes();

        if (this.izm.GetZoneAttributes((uint)zone, ref za) == 0)
        {
            return za;
        }

        throw new Exception();
    }

    public void SetZoneAttributes(UrlZone zone, ZoneAttributes attributes)
    {
        attributes.Size = (uint)Marshal.SizeOf(attributes);

        if (this.izm.SetZoneAttributes((uint)zone, ref attributes) != 0)
        {
            throw new Exception();
        }
    }

    public byte[] GetZoneActionPolicy(UrlZone zone, UrlAction action, UrlZoneReg zoneReg)
    {
        IntPtr pPolicy = Marshal.AllocHGlobal(8196);

        try
        {
            if (this.izm.GetZoneActionPolicy((uint)zone, (uint)action, pPolicy, 8196, (uint)zoneReg) == 0)
            {
                byte[] buff = new byte[8196];

                for (int i = 0; i < buff.Length; i++)
                {
                    buff[i] = Marshal.ReadByte(pPolicy, i);
                }

                return buff;
            }

            throw new Exception();
        }
        finally
        {
            Marshal.FreeHGlobal(pPolicy);
        }
    }

    public int CopyTemplatePoliciesToZone(URLTEMPLATE template, UrlZone zone)
    {
        try
        {
            if (this.izm.CopyTemplatePoliciesToZone((uint)template, (uint)zone, 0) == 0)
            {
                return 0;
            }
            throw new Exception();
        }
        finally { }
    }

    public void Dispose()
    {
        if (this.izm != null)
        {
            Marshal.ReleaseComObject(this.izm);
            this.izm = null;
        }

        GC.SuppressFinalize(this);
    }
}