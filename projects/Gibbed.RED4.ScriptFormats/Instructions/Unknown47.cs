﻿/* Copyright (c) 2020 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

namespace Gibbed.RED4.ScriptFormats.Instructions
{
    [Instruction(Opcode.Unknown47)]
    public struct Unknown47
    {
        public const int ChainCount = 0;

        public byte[] Bytes;
        public byte Unknown;

        public Unknown47(byte[] bytes, byte unknown)
        {
            this.Bytes = bytes;
            this.Unknown = unknown;
        }

        internal static (object, uint) Read(IDefinitionReader reader)
        {
            var bytes = reader.ReadBytes();
            var unknown = reader.ReadValueU8();
            return (new Unknown47(bytes, unknown), (uint)bytes.Length + 5);
        }

        internal static uint Write(object argument, IDefinitionWriter writer)
        {
            var (bytes, unknown) = (Unknown47)argument;
            writer.WriteBytes(bytes);
            writer.WriteValueU8(unknown);
            return (uint)bytes.Length + 5;
        }

        public void Deconstruct(out byte[] bytes, out byte unknown)
        {
            bytes = this.Bytes;
            unknown = this.Unknown;
        }

        public override string ToString()
        {
            return $"({this.Bytes}, {this.Unknown})";
        }
    }
}
