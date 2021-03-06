﻿using Advent2016.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class RoomFixture
    {

        /*
        aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a (5), b (3), and then a tie between x, y, and z, which are listed alphabetically.
a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
not-a-real-room-404[oarel] is a real room.
totally-real-room-200[decoy]
*/
        [TestMethod]
        public void ParseRoom_abxyz()
        {
            var input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var room = new Room(input);
            Assert.AreEqual("abxyz", room.Checksum);
            Assert.AreEqual(123, room.Sector);
            Assert.AreEqual("aaaaa-bbb-z-y-x", room.EncryptedName);
        }

        [TestMethod]
        public void ParseRoom_abcde()
        {
            var input = "a-b-c-d-e-f-g-h-987[abcde]";
            var room = new Room(input);
            Assert.AreEqual("abcde", room.Checksum);
            Assert.AreEqual(987, room.Sector);
            Assert.AreEqual("a-b-c-d-e-f-g-h", room.EncryptedName);
        }

        [TestMethod]
        public void ParseRoom_oarel()
        {
            var input = "not-a-real-room-404[oarel]";
            var room = new Room(input);
            Assert.AreEqual("oarel", room.Checksum);
            Assert.AreEqual(404, room.Sector);
            Assert.AreEqual("not-a-real-room", room.EncryptedName);
        }

        [TestMethod]
        public void ParseRoom_decoy()
        {
            var input = "totally-real-room-200[decoy]";
            var room = new Room(input);
            Assert.AreEqual("decoy", room.Checksum);
            Assert.AreEqual(200, room.Sector);
            Assert.AreEqual("totally-real-room", room.EncryptedName);
        }
    }
}
