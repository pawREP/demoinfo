using System;
using System.IO;

// Analysis disable once CheckNamespace
namespace EHVAG.DemoInfo.Utils
{
    interface IBitStream : IDisposable
    {
        /// <summary>
        /// Initialize the specified stream as an BitStream
        /// </summary>
        /// <param name="stream">Stream.</param>
        void Initialize(Stream stream);

        /// <summary>
        /// Reads n bits, and converts those to an integer. 
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="bits">Bits.</param>
        uint ReadInt(int bits);

        /// <summary>
        /// Reads a signed integer
        /// </summary>
        /// <returns>The signed int.</returns>
        /// <param name="numBits">Number bits.</param>
        int ReadSignedInt(int numBits);

        /// <summary>
        /// Returns true if the next bit is 1, else false, and avances the stream
        /// </summary>
        /// <returns><c>true</c>, if bit was  read, <c>false</c> otherwise.</returns>
        bool ReadBit();

        /// <summary>
        /// Reads 8 bits, and returns the resulting byte
        /// </summary>
        /// <returns>The byte.</returns>
        byte ReadByte();

        /// <summary>
        /// Reads n bits into a byte
        /// </summary>
        /// <returns>The byte.</returns>
        /// <param name="bits">Bits.</param>
        byte ReadByte(int bits);

        /// <summary>
        /// Reads an byte-array 
        /// </summary>
        /// <returns>The bytes.</returns>
        /// <param name="bytes">Bytes.</param>
        byte[] ReadBytes(int bytes);

        /// <summary>
        /// Reads a float.
        /// </summary>
        /// <returns>The float.</returns>
        float ReadFloat();

        /// <summary>
        /// Reads an byte-array from n bits. The returned byte-array has a size of (int)((bits + 7)/8) bytes
        /// </summary>
        /// <returns>The resulting byte-array.</returns>
        /// <param name="bits">Bits.</param>
        byte[] ReadBits(int bits);

        /// <summary>
        /// Reads a protobuf varint (non-zigzag-encoded)
        /// </summary>
        /// <returns>The protobuf varint.</returns>
        int ReadProtobufVarInt();


        // Chunking: You can begin chunks with a specified length.
        // You can then determine whether you've already read
        // the full chunk. You can also end the chunk and skip
        // ahead to where you would be had you read everything.
        // Chunks can be nested and it'll work just like you'd
        // expect (stack-like).
        //
        // tl;dr bitstream chunks are basically LimitStreams

        /// <summary>
        /// Begins a chunk.
        /// </summary>
        /// <param name="bits">The chunk's length in bits.</param>
        /// <remarks>
        /// You must not try to read beyond the end of a chunk. Doing
        /// so may corrupt the bitstream's state, leading to
        /// implementation-defined behavior of all methods except
        /// <c>Dispose</c>.
        /// </remarks>
        void BeginChunk(int bits);

        /// <summary>
        /// Ends a chunk.
        /// </summary>
        /// <remarks>
        /// If there's no current chunk, this method <c>may</c> throw
        /// and leave the bitstream in an undefined state that can
        /// be cleaned up safely by disposing it.
        /// Alternatively, it may also return normally if it didn't
        /// corrupt or otherwise modify the bitstream's state.
        /// </remarks>
        void EndChunk();

        /// <summary>
        /// Gets a value indicating whether the current chunk was fully read.
        /// </summary>
        /// <value><c>true</c> if chunk is finished; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// The return value is undefined if there's no current chunk.
        /// </remarks>
        bool ChunkFinished { get; }
    }
}

