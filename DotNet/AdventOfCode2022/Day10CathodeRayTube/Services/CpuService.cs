using Day10CathodeRayTube.Domain;
using System;
using System.Text;

namespace Day10CathodeRayTube.Services
{
    public class CpuService
    {
        public Cpu Cpu { get; private set; }

        public CpuService(Cpu cpu)
        {
            Cpu = cpu;
        }

        public void ApplyInstruction(string instruction)
        {
            if (instruction.Equals("noop"))
            {
                Cpu.Noop();
            }
            else
            {
                // addx
                Cpu.AddX(Convert.ToInt32(instruction.Split(' ')[1]));
            }
        }

        public string DrawImage(int spriteWidth = 3, int screenWidth = 40)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int cycle = 1; cycle <= 240; cycle++)
            {
                stringBuilder.Append(ReadPixel(cycle, spriteWidth, screenWidth));
                if (cycle % screenWidth == 0)
                {
                    stringBuilder.AppendLine();
                }
            }
            return stringBuilder.ToString();
        }

        private char ReadPixel(int cycle, int spriteWidth, int screenWidth)
        {
            int signalStrength = Cpu.GetSignalStrenghtForCycle(cycle);
            for (int i = 0; i < spriteWidth; i++)
            {
                if ((signalStrength + i) % screenWidth == cycle % screenWidth)
                {
                    // If it targets one of the pixels of the sprite
                    return '#';
                }
            }
            return '.';
        }
    }
}
