using mzmr;
using System;

namespace mzmrTests
{
    public static class Tests
    {
        private const string romPath = @"C:\Users\kwlab\Desktop\gbamet\zm_u.gba";

        public static Rom TestRom => new Rom(romPath);

    }
}
