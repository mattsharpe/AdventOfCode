using System;
using System.Linq;

namespace AdventOfCode.Utilities
{
    public class Room
    {
        public int Sector { get; set; }
        public string Checksum { get; set; }
        public string EncryptedName { get; set; }

        public Room(string roomName)
        {
            var parts = roomName.Split('-');
            var checksum = parts.Last();

            Sector = Convert.ToInt32(checksum.Split('[')[0]);
            Checksum = checksum.Split('[')[1].Replace("]","");
            EncryptedName = roomName.Remove(roomName.LastIndexOf('-'));
        }
    }
}
