//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DogWalker.V3Files.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WALK
    {
        public int WalkID { get; set; }
        public int DogID { get; set; }
        public System.DateTime Date { get; set; }
        public string Time { get; set; }
    
        public virtual DOG DOG { get; set; }
    }
}