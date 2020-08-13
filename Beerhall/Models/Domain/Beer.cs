using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beerhall.Models.Domain
{
    public class Beer
    {
        #region Fields

        private string _name { get; set; }

        #endregion

        #region Properties

        public double? AlcoholByVolume { get; set; }
        public bool AlcoholKnown => AlcoholByVolume.HasValue;
        public int BeerId { get; set; }
        public string Description { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A beer must have a name");
                _name = value;
            }
        }
        public decimal Price { get; set; }

        #endregion

        #region Constructors

        public Beer()
        {

        }

        public Beer(string name)
        {
            Name = name;
        }

        #endregion
    }
}
