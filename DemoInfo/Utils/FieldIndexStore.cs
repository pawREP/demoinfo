using System;
using System.Collections.Generic;

namespace EHVAG.DemoInfo.Utils
{
    /// <summary>
    /// Field index store. It storse field-indicies of Entity-Updates
    /// </summary>
    public struct FieldIndexStore
    {
        const int MAXBITS = 12;
        const int MASK = (1 << MAXBITS) - 1;

        const int INTS_PER_LONG = 64 / MAXBITS;
        const int INTS_PER_LONG_2 = INTS_PER_LONG * 2;
        const int INTS_PER_LONG_3 = INTS_PER_LONG * 3;



        /* What we do here is basically cheating.
         * The field-index is at maximum 12 bits long
         * So we only store these bits. The big advantage is
         * That we keep the processor-cache clean
         * This is a micro-optimization, but it works :)
         * 
         * You could use a List<int>, but that'd be slower :)
         */

        public int Count {
            get {
                return current;
            }
        }

        private long Value1;
        private long Value2;
        private long Value3;

        private List<long> fieldIndicies;

        int current;

        /// <summary>
        /// Add the specified input to the fieldindex-store. If it's bigger than 12 bits, it's truncated
        /// </summary>
        /// <param name="input">Input.</param>
        public void Add(long input)
        {
            input &= MASK;
            if (current < INTS_PER_LONG)
            {
                Value1 |= input << (current * MAXBITS);
            } 
            else if (current < INTS_PER_LONG_2)
            {
                Value2 |= input << ((current - INTS_PER_LONG) * MAXBITS);
            }
            else if (current < INTS_PER_LONG_3)
            {
                Value3 |= input << ((current - INTS_PER_LONG_2) * MAXBITS);
            }
            else if (current == INTS_PER_LONG_3)
            {
                // this is a huge update :)
                fieldIndicies = new List<long>() { input };
            }
            else 
            {
                fieldIndicies.Add(input);
            }
            current++;
        }

        /// <summary>
        /// Gets the <see cref="EHVAG.DemoInfo.Utils.FieldIndexStore"/> with the specified position.
        /// </summary>
        /// <param name = "index">The position to read from</param>
        public long this[int index] 
        {
            get 
            {
                if (index < INTS_PER_LONG)
                {
                    return (Value1 >> (index * MAXBITS)) & MASK;
                } 
                else if (index < INTS_PER_LONG_2)
                {
                    return (Value2 >> ((index - INTS_PER_LONG) * MAXBITS)) & MASK;
                }
                else if (index < INTS_PER_LONG_3)
                {
                    return (Value3 >> ((index - INTS_PER_LONG_2) * MAXBITS)) & MASK;
                }
                else 
                {
                    return fieldIndicies[index - INTS_PER_LONG_3];
                }
            }
        }
    }
}

