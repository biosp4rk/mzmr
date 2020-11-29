using mzmr;
using System;

namespace mzmrTests
{
    public static class Tests
    {
        private const string romPath = @"C:\Users\kwlab\source\repos\mzmr\asm\items\ZM_U.gba";

        public static Rom TestRom => new Rom(romPath);

    }
}
