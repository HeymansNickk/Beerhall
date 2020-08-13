using Beerhall.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beerhall.Models.ViewModels
{
    public class BrewerEditViewModel
    {
        #region Properties

        public string Name { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int? Turnover { get; set; }

        #endregion


        #region Constructors

        public BrewerEditViewModel()
        {

        }

        public BrewerEditViewModel(Brewer brewer) : this()
        {
            Name = brewer.Name;
            Street = brewer.Street;
            PostalCode = brewer.Location?.PostalCode;
            Turnover = brewer.Turnover;
        }

        #endregion

    }
}
