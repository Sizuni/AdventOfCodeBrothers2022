using System.Collections.Generic;
using System.Linq;

namespace Day06TuningTrouble
{
    public class CommunicationSystemService
    {
        public static int FindStartOfPacketMarker(string datastream, int uniqueCharacterSequenceLength = 4)
        {
            // Prepare queue with the required sequence length
            Queue<char> sequence = new Queue<char>(datastream.Substring(0, uniqueCharacterSequenceLength));
            if (sequence.Distinct().Count() == uniqueCharacterSequenceLength)
            {
                return uniqueCharacterSequenceLength;
            }

            for (int i = uniqueCharacterSequenceLength; i < datastream.Length; i++)
            {
                sequence.Dequeue();
                sequence.Enqueue(datastream.ElementAt(i));
                if (sequence.Distinct().Count() == uniqueCharacterSequenceLength)
                {
                    return i + 1;
                }
                
            }

            return 0;
        }
    }
}
