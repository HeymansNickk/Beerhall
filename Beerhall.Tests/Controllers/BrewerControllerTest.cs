using Beerhall.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Beerhall.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace Beerhall.Tests.Controllers
{
    public class BrewerControllerTest
    {
        private BrewerController _controller;
        private Mock<IBrewerRepository> _brewerRepository;
        private Mock<ILocationRepository> _locationRepository;
        private readonly DummyApplicationDbContext _dummyContext;

        public BrewerControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _brewerRepository = new Mock<IBrewerRepository>();
            _locationRepository = new Mock<ILocationRepository>();
            _controller = new BrewerController(_brewerRepository.Object, _locationRepository.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;
        }

        #region IndexTest

        public void Index_PassesOrderedListOfBrewersInViewResultModelAndStoresTotalTurnoverInViewData()
        { 
            //Arange
            _brewerRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Brewers);
            
            //Act
            var result = Assert.IsType<ViewResult>(_controller.Index());

            //Assert
            var brewersInModel = Assert.IsType<List<Brewer>>(result.Model);
            Assert.Equal(3, brewersInModel.Count);
            Assert.Equal("Bavik", brewersInModel[0].Name);
            Assert.Equal("De Leeuw", brewersInModel[1].Name); 
            Assert.Equal("Duvel Moortgat", brewersInModel[2].Name); 
            Assert.Equal(20050000, result.ViewData["TotalTurnover"]);
        }

        #endregion

        #region EditTest

        public void Edit_ValidEdit_UpdatesAndPersistsBrewerAndRedirectsToActionIndex()
        {
            _brewerRepository.Setup(m => m.GetBy(1)).Returns(_dummyContext.Bavik);
            var brewerEvm = new BrewerEditViewModel(_dummyContext.Bavik)
            {
                Street = "nieuwe straat 1"
            };
            var result = Assert.IsType<RedirectToActionResult>(_controller.Edit(brewerEvm, 1));
            var bavik = _dummyContext.Bavik;
            Assert.Equal("Index", result?.ActionName);
            Assert.Equal("Bavik", bavik.Name);
            Assert.Equal("nieuwe straat 1", bavik.Street);
            _brewerRepository.Verify(m => m.SaveChanges(), Times.Once());
        }

        #endregion
    }
}
