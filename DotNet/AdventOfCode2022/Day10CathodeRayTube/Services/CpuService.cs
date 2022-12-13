using Day10CathodeRayTube.Domain;
using System;

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
    }
}
