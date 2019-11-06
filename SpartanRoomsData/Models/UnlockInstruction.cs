using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public enum unlockType
    {
        key, code, none
    }
    public class UnlockInstruction
    {
        public int UnlockInstructionID { get; set; }
        public unlockType UnlockType { get; set; }

        public string? Instruction { get; set; }


    }
}
