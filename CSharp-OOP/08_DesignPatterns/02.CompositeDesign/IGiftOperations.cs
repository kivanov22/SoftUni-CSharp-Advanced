using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CompositeDesign
{
   public interface IGiftOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
