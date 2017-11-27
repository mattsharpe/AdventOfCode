using System.Linq;
using System.Text;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
    /*
    --- Day 4: Security Through Obscurity ---

    Finally, you come across an information kiosk with a list of rooms. Of course, the list is encrypted and full of decoy data, but the instructions to decode the list are barely hidden nearby. Better remove the decoy data first.

    Each room consists of an encrypted name (lowercase letters separated by dashes) followed by a dash, a sector ID, and a checksum in square brackets.

    A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, in order, with ties broken by alphabetization. For example:

    aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a (5), b (3), and then a tie between x, y, and z, which are listed alphabetically.
    a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
    not-a-real-room-404[oarel] is a real room.
    totally-real-room-200[decoy] is not.
    Of the real rooms from the list above, the sum of their sector IDs is 1514.

    What is the sum of the sector IDs of the real rooms?

--- Part Two ---

With all the decoy data out of the way, it's time to decrypt this list and get moving.

The room names are encrypted by a state-of-the-art shift cipher, which is nearly unbreakable without the right software. However, the information kiosk designers at Easter Bunny HQ were not expecting to deal with a master cryptographer like yourself.

To decrypt a room name, rotate each letter forward through the alphabet a number of times equal to the room's sector ID. A becomes B, B becomes C, Z becomes A, and so on. Dashes become spaces.

For example, the real name for qzmt-zixmtkozy-ivhz-343 is very encrypted name.

What is the sector ID of the room where North Pole objects are stored?

    */

    public class Day4
    {
        public string[] LoadData()
        {
            return FileReader.ReadFile("day4 room codes.txt");
        }

        public bool VerifyRoom(Room room)
        {
            //A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, 
            //in order, with ties broken by alphabetization.

            var dict = room.EncryptedName.Replace("-","").ToLookup(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key);
            var checksum = string.Join("", dict.Take(5).Select(x => x.Key));

            return room.Checksum == checksum;
        }

        public int CalculateTotal(string[] input)
        {
            return input.Select(x => new Room(x)).Where(VerifyRoom).Sum(x => x.Sector);
        }

        public int Part1()
        {
            return CalculateTotal(LoadData());
        }

        public string ShiftCipher(string input, int shift)
        {
            var sb = new StringBuilder();
            foreach (char letter in input)
            {
                if (letter == '-')
                {
                    sb.Append(" ");
                    continue;
                }
                var increase = letter + shift%26;
                if (increase > 'z') increase -= 26;
                sb.Append((char) increase);
            }
            return sb.ToString();
        }

        public int Part2()
        {
            //Which sector are the North Pole objects in?
            return LoadData().Select(x => new Room(x))
                .Single(x => ShiftCipher(x.EncryptedName, x.Sector) == "northpole object storage").Sector;
        }
    }
}