using System;
using System.Runtime.InteropServices;

namespace SharpPresence
{
    internal class Discord
    {
        //--------------------------------------------------------------------------------

        public enum Reply
        {
            No = 0,
            Yes = 1,
            Ignore = 2
        }

        //--------------------------------------------------------------------------------

        /// <summary>
        ///     Initializes discord rich presence
        /// </summary>
        /// <param name="applicationID"></param>
        /// <param name="handlers"></param>
        /// <param name="autoRegister"></param>
        /// <param name="optionalSteamId"></param>
        [DllImport("discord-rpc.dll")]
        private static extern void Discord_Initialize([MarshalAs(UnmanagedType.LPStr)] string applicationID,
            ref EventHandlers handlers,
            int autoRegister,
            [MarshalAs(UnmanagedType.LPStr)] string optionalSteamId);

        public static void Initialize(string appID, EventHandlers handlers)
        {
            Discord_Initialize(appID, ref handlers, 1, string.Empty);
        }

        //--------------------------------------------------------------------------------

        [DllImport("discord-rpc.dll")]
        private static extern void Discord_UpdatePresence(IntPtr presence);

        public static void UpdatePresence(RichPresence presence)
        {
            var ptrPresence = Marshal.AllocHGlobal(Marshal.SizeOf(presence));
            Marshal.StructureToPtr(presence, ptrPresence, false);
            Discord_UpdatePresence(ptrPresence);
        }

        //--------------------------------------------------------------------------------

        [DllImport("discord-rpc.dll")]
        private static extern void Discord_Shutdown();

        public static void Shutdown()
        {
            Discord_Shutdown();
        }

        //--------------------------------------------------------------------------------

        [DllImport("discord-rpc.dll")]
        private static extern void Discord_UpdateConnection();

        public static void UpdateConnection()
        {
            Discord_UpdateConnection();
        }

        //--------------------------------------------------------------------------------

        [DllImport("discord-rpc.dll")]
        private static extern void Discord_RunCallbacks();

        public static void RunCallbacks()
        {
            Discord_RunCallbacks();
        }
        //--------------------------------------------------------------------------------

        [DllImport("discord-rpc.dll")]
        private static extern void Discord_Respond(string userId, int reply);

        public static void Respond(string userID, Reply reply)
        {
            Discord_Respond(userID, (int)reply);
        }

        public struct EventHandlers
        {
            public IntPtr ready;
            public IntPtr disconnected;
            public IntPtr errored;
            public IntPtr joinGame;
            public IntPtr spectateGame;
            public IntPtr joinRequest;
        }

        //--------------------------------------------------------------------------------

        public struct RichPresence
        {
            public string state;
            public string details;
            public long startTimestamp;
            public long endTimestamp;
            public string largeImageKey;
            public string largeImageText;
            public string smallImageKey;
            public string smallImageText;
            public string partyId;
            public int partySize;
            public int partyMax;
            public string matchSecret;
            public string joinSecret;
            public string spectateSecret;
            public sbyte instance;
        }

        //--------------------------------------------------------------------------------

        public struct JoinRequest
        {
            public string userId;
            public string username;
            public string avatar;
        }
    }
}